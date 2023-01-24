using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashSkill : PlayerSkill
{
    private float dash_timer_ = 0.0f;       //�X�L�����������ԃJ�E���g�p
    private const float DASH_TIME = 1.0f;   //�X�L����������

    public void Start()
    {
        //�X�L���̃`���[�W���Ԃ�ݒ�
        SKILL_CHRGE_TIME = 1.5f;

    }

    public override bool enterSkill() 
    {
        //�X�L���`���[�W���Ԃ��I����Ă��Ȃ���Δ������Ȃ�
        if (skill_timer_ < SKILL_CHRGE_TIME)
            return false;

        //�v���C���[�̈ړ����x�ύX
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

        //�������ԏI������
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
        //�v���C���[�̈ړ����x�����ɖ߂�
        player_inter_face_.player_move_.move_speed_ = player_inter_face_.player_move_.move_speed_ / 1.5f;

        dash_timer_ = 0.0f;
    }
}
