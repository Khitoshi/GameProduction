using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//エネミー用の動きを制御するクラス
public class EnemyMove : CharacterMove
{
    //動きを切替時のタイミングを測るタイマー
    private float switch_timer_ = 0.0f;

    //横軸のみ移動時の移動方向切替タイム
    public float HORIZONAL_SWITCH_TIME = 0.0f;

    private Vector3 wander_move_position = new Vector3(0,0,0);

    public CircleCollider2D circle_collider;

    private Vector3 last_time_euler;

    //横軸のみに動く敵
    public void horizonalMove()
    {
        if (switch_timer_ > HORIZONAL_SWITCH_TIME)
        {
            if (add_speed_.x <= 0.0f)
                add_speed_.x = move_speed_;
            else
                add_speed_.x = -move_speed_;

            switch_timer_ = 0.0f;
        }

        switch_timer_ += Time.deltaTime;
    }

    public void rotationOnlyMove(Vector3 target)
    {
        Vector3 latest_euler = new Vector3(0,0,0);
        if (latest_euler != last_time_euler)
        {
            Debug.Log("rotation");
            transform.Rotate(latest_euler, Space.World);
        }
        last_time_euler = latest_euler;
    }
    
    public Vector3 setWanderPosition()
    {
        //目的地に到着していない場合
        Debug.Log(wander_move_position);

        //ターゲットに到着しているかの判定
        if (transform.position != wander_move_position && wander_move_position != new Vector3(0, 0, 0)) return wander_move_position;
        //circle_collider = GetComponent<CircleCollider2D>();
        //circle_collider = GetComponent<CircleCollider2D>();

        // CircleColliderの半径を取得
        float radius = circle_collider.radius;

        // CircleCollider内のランダムな位置を計算
        wander_move_position = Random.insideUnitCircle * radius;

        return wander_move_position;
    }

    /*
    public Vector3 wanderMove(Transform transform)
    {
        Vector3 target_pos = setWanderPosition();
        Debug.Log(target_pos);
        return moveToTarget(transform, target_pos);
    }
    */

    public Vector3 moveToTarget(Transform mine_transform, Vector3 target_position)
    {

        Vector3 direction = mine_transform.position - target_position;

        //自身の回転値から前方向ベクトルを求める
        float angle_radian = mine_transform.localEulerAngles.z;
        angle_radian *= 0.01745f; //rad = dgree * (π/180)
        float add_right_angle = 1.5705f; //90度分数値を足してあげないと前方向にならない

        angle_radian += add_right_angle;

        float front_x = Mathf.Cos(angle_radian);
        float front_y = Mathf.Sin(angle_radian);

        //内積により、ターゲットとどれくらい角度差があるか計算する
        float dot = front_x * direction.normalized.x + front_y * direction.normalized.y;

        //補正値(内積値-1.0～1.0を角度小：0.0～2.0：角度大に補正します)
        float rot = 1.0f - dot;

        //内積値は-1.0～1.0で表現されており、2つの単位ベクトルの角度が
        //小さいほど1.0に近づくという性質を利用して回転速度を調整する
        if (rot > rotate_speed_)
        {
            rot = rotate_speed_;
        }

        //左右判定を行うために2つの単位ベクトルの外積を計算する
        float cross = front_x * direction.normalized.y - front_y * direction.normalized.x;  //外積の公式

        //ターゲット方向までの回転処理
        //2Dの外積値が正の場合か負の場合によって左右判定が行える
        //左右判定を行うことによって左右回転を選択する
        if (cross < 0.0f)
        {
            Vector3 rotate = new Vector3(0.0f, 0.0f, rot);
            mine_transform.Rotate(rotate);
        }
        else
        {
            Vector3 rotate = new Vector3(0.0f, 0.0f, -rot);
            mine_transform.Rotate(rotate);
        }

        Vector3 update_position = mine_transform.position;
        update_position = Vector3.MoveTowards(mine_transform.position, target_position, move_speed_ * Time.deltaTime);

        return update_position;
    }



}
