using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�ϑ��X�L���A�G�̔������肩�瓦���
public class DisguiseSkill : PlayerSkill
{
    private float disguise_timer_ = 0.0f;       //�X�L�����������ԃJ�E���g�p
    private const float DISGUISE_TIME = 5.0f;   //�X�L����������
    private bool is_disguise_ = false;  //�ϑ����t���b�O
    public bool is_disguise { get { return is_disguise_; } set { is_disguise_ = value; } }
    // Start is called before the first frame update
    void Start()
    {

    }

    public override bool enterSkill()
    {
        //�X�L���`���[�W���Ԃ��I����Ă��Ȃ���Δ������Ȃ�
        if (skill_timer_ < SKILL_CHRGE_TIME)
            return false;

        is_active_ = true;

        skill_timer_ = 0.0f;

        is_disguise = true;

        //�e�I�u�W�F�N�g�̎擾����(�v���C���[�I�u�W�F�N�g)
        var parent_object = transform.root.gameObject;

        parent_object.GetComponent<Animator>().SetBool("DisguiesTrigger", is_disguise);

        //�����̖��O�̃��C���[�ԍ����擾����
        parent_object.layer = LayerMask.NameToLayer("DisguisePlayer");

        return true;
    }

    public override void moveSkill()
    {
        if (!is_active_)
        {
            return;
        }

        //�������ԏI������
        if (disguise_timer_ > DISGUISE_TIME)
        {
            is_active_ = false;
            endSkill();
            return;
        }

        disguise_timer_ += Time.deltaTime;
    }

    public override void endSkill()
    {

        //�e�I�u�W�F�N�g�̎擾����(�v���C���[�I�u�W�F�N�g)
        var parent_object = transform.root.gameObject;
        parent_object.layer = LayerMask.NameToLayer("Player");

        is_disguise = false;

        parent_object.GetComponent<Animator>().SetBool("DisguiesTrigger", is_disguise);

        disguise_timer_ = 0.0f;
    }
}
