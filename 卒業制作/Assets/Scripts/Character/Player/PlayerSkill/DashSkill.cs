using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashSkill : PlayerSkill
{
    private float dash_timer_ = 0.0f;       //スキル発動中時間カウント用
    private const float DASH_TIME = 1.0f;   //スキル発動時間

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

        //プレイヤーの移動速度変更
        player_inter_face_.player_move_.move_speed_ = player_inter_face_.player_move_.move_speed_ * 1.5f;

        is_active_ = true;

        skill_timer_ = 0.0f;

        return true;
    }

    public override void moveSkill() 
    {
        if(!is_active_)
        {
            return;
        }

        //発動時間終了判定
        if(dash_timer_ > DASH_TIME)
        {
            is_active_ = false;
            endSkill();
            return;
        }

        dash_timer_ += Time.deltaTime;
    }

    public override void endSkill() 
    {
        //プレイヤーの移動速度を元に戻す
        player_inter_face_.player_move_.move_speed_ = player_inter_face_.player_move_.move_speed_ / 1.5f;

        dash_timer_ = 0.0f;
    }
}
