using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashSkill : PlayerSkill
{

    public void Start()
    {
        SKILL_CHRGE_TIME = 1.0f;
    }

    public override void enterSkill() 
    {
        //プレイヤーの移動速度変更
        player_inter_face_.player_move_.move_speed_ = player_inter_face_.player_move_.move_speed_ * 1.5f;

        is_active_ = true;
    }

    public override void moveSkill() 
    {
        if(!is_active_)
        {
            return;
        }

        //発動時間終了判定
        if(skill_timer_ > SKILL_CHRGE_TIME)
        {
            is_active_ = false;
            endSkill();
            return;
        }

        skill_timer_ += Time.deltaTime;
    }

    public override void endSkill() 
    {
        //プレイヤーの移動速度を元に戻す
        player_inter_face_.player_move_.move_speed_ = player_inter_face_.player_move_.move_speed_ / 1.5f;

        skill_timer_ = 0.0f;
    }
}
