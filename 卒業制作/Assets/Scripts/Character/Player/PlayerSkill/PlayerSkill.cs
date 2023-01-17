using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�v���C���[�X�L���𐧌䂷����N���X
public class PlayerSkill : MonoBehaviour
{
    //�v���C���[���ݒ�o����X�L���̎��
    private enum PLAYER_SKILL_LABEL
    {
        none = 0,   //�X�L������
        dash,       //�_�b�V���X�L��
        invincible, //���G
        wave,       //�g��
    }

    public PlayerInterFace player_inter_face_;

    private PLAYER_SKILL_LABEL skill_deiffrence_ { get; }
    public int getMineSkillNo() { return (int)skill_deiffrence_; }

    //�X�L�������܂鎞��
    public float SKILL_CHRGE_TIME = 3.0f;

    //�X�L���`���[�W�̃J�E���g�p�^�C�}�[
    public float skill_timer_ = 0.0f;

    //�X�L��������
    public bool is_active_ = false;

    public PlayerSkill()
    {
        player_inter_face_ = GetComponent<PlayerInterFace>();
    }


    //�X�L����������
    public virtual void enterSkill() { }
    //�X�L������������
    public virtual void moveSkill() { }

    //�X�L�������㏈��
    public virtual void endSkill() { }
}
