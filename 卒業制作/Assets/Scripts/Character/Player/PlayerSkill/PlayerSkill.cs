using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�v���C���[�X�L���𐧌䂷����N���X
public class PlayerSkill : MonoBehaviour
{
    //�v���C���[���ݒ�o����X�L���̎��
    public enum PLAYER_SKILL_LABEL
    {
        none = 0,   //�X�L������
        dash,       //�_�b�V���X�L��
        disguise, //�ϑ�
        wave,       //�g��
    }

    [SerializeField]
    protected PlayerInterFace player_inter_face_;

    private PLAYER_SKILL_LABEL skill_deiffrence_ { get; }
    public int getMineSkillNo() { return (int)skill_deiffrence_; }

    //�X�L�������܂鎞��
    public float SKILL_CHRGE_TIME = 3.0f;

    //�X�L���`���[�W�̃J�E���g�p�^�C�}�[
    public float skill_timer_ = 0.0f;

    //�X�L��������
    public bool is_active_ = false;

    private void Start()
    {
        
    }

    //�X�L����������
    public virtual bool enterSkill() { return false; }
    //�X�L������������
    public virtual void moveSkill() { }

    //�X�L�������㏈��
    public virtual void endSkill() { }

    //�X�L�������^�C�}�[�J�E���g�p�֐�
    public void skillChargeTimer() 
    {
        //�X�L���������̓J�E���g���Ȃ�
        if (is_active_)
            return;

        if(skill_timer_ >= SKILL_CHRGE_TIME)
        {
            skill_timer_ = SKILL_CHRGE_TIME;
            return;
        }

        skill_timer_ += Time.deltaTime;
    }
}
