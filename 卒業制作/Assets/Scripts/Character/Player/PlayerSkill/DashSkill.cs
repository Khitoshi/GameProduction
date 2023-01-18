using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashSkill : PlayerSkill
{

    public void Start()
    {
        SKILL_CHRGE_TIME = 3.0f;
    }

    public override void enterSkill() 
    {
        //�v���C���[�̈ړ����x�ύX
        player_inter_face_.player_move_.move_speed_ = player_inter_face_.player_move_.move_speed_ * 2.0f;

        is_active_ = true;
    }

    public override void moveSkill() 
    {
        if(!is_active_)
        {
            return;
        }

        //�������ԏI������
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
        //�v���C���[�̈ړ����x�����ɖ߂�
        player_inter_face_.player_move_.move_speed_ = player_inter_face_.player_move_.move_speed_ / 2.0f;

        skill_timer_ = 0.0f;
    }
}
