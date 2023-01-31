using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//プレイヤーが波動を飛ばすスキル
public class WaveSkill : PlayerSkill
{

    //波動のプレハブ
    [SerializeField]
    private GameObject wave_object_prefab_;

    //プレハブからロードしたデータを直接削除出来ないので複製用にデータを用意する
    private GameObject wave_object_;

    private float wave_timer_ = 0.0f;       //スキル発動中時間カウント用
    private const float WAVE_TIME = 2.0f;   //スキル発動時間
    public float wave_speed_ = 3.0f;    //波動の進行速度
    private float wave_direction_ = 0.0f;   //波動の進行方向
    public float wave_power_ = 5.0f;     //波動のノックバックパワー
    private PlayerWaveCollision wave_hit_event_;

    public void Start()
    {
        //スキルのチャージ時間を設定
        SKILL_CHRGE_TIME = 1.5f;

    }

    public override bool enterSkill()
    {
        //スキルチャージ時間が終わっていなければ発動しない
        if (skill_timer_ < SKILL_CHRGE_TIME)
            return false;

        //waveオブジェクト作成、プレイヤーの姿勢情報を送る
        wave_object_ = Instantiate<GameObject>(wave_object_prefab_) as GameObject;

        wave_direction_ = player_inter_face_.player_move_.direction_angle_;
        wave_object_.transform.position = player_inter_face_.transform.position;

        //波動ヒット用コンポーネントをprefabから生成したオブジェクトから取得
        wave_hit_event_ = wave_object_.GetComponent<PlayerWaveCollision>();
        //ヒットイベント登録
        wave_hit_event_.on_hit_wave_enemy_function_ += hitEnemy;
        wave_hit_event_.on_hit_wave_other_function_ += hitOther;

        is_active_ = true;

        skill_timer_ = 0.0f;

        return true;
    }

    public override void moveSkill()
    {
        if (!is_active_)
        {
            return;
        }

        //発動時間終了判定
        if (wave_timer_ > WAVE_TIME)
        {
            is_active_ = false;
            endSkill();

            //スキル発動時間終わりなので自身を削除
            if (wave_object_ != null)
                Destroy(wave_object_);
            return;
        }

        waveMove();
        wave_timer_ += Time.deltaTime;
    }

    public override void endSkill()
    {
        is_active_ = false;
        wave_timer_ = 0.0f;

        Destroy(wave_object_);
    }

    //波動の動き
    private void waveMove()
    {
        Vector3 direction = new Vector3(Mathf.Cos(wave_direction_), Mathf.Sin(wave_direction_), 0.0f);

        float wave_speed_frame_ = wave_speed_ * Time.deltaTime;

        Vector3 wave_update = new Vector3(direction.x * wave_speed_frame_, direction.y * wave_speed_frame_, 0.0f);

        //座標更新
        wave_object_.transform.position = wave_object_.transform.position + wave_update;
    }

    public void hitEnemy(Collider2D collision)
    {
        if (collision.gameObject != null)
        {
            collision.attachedRigidbody.AddForce(new Vector2(Mathf.Cos(wave_direction_) * wave_power_, Mathf.Sin(wave_direction_) * wave_power_));
        }
        endSkill();
        Destroy(wave_object_);
    }

    public void hitOther(Collider2D collision)
    {
        endSkill();
        Destroy(wave_object_);
    }


}
