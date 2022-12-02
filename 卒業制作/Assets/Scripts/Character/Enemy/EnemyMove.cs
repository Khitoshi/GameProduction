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

    public void rotationOnlyMove()
    {
        Vector3 update_euler = new Vector3(0.0f, 0.0f, 30.0f * Time.deltaTime);
        transform.Rotate(update_euler, Space.World);
    }

    //ターゲットを追跡する関数
    public Vector3 moveToTarget(Vector3 mine_position, Vector3 target_position)
    {
        Vector3 update_position = mine_position;
        update_position = Vector2.MoveTowards(mine_position, target_position,move_speed_ * Time.deltaTime);

        return update_position;
    }

}
