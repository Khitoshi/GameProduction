using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�ϑ��X�L���A�G�̔������肩�瓦���
public class DisguiseSkill : PlayerSkill
{
    private float disguise_timer_ = 0.0f;       //�X�L�����������ԃJ�E���g�p
    private const float DISGUISE_TIME = 5.0f;   //�X�L����������
    public Sprite disguise_sprite_ = null;
    private Sprite save_sprite_ = null;
    // Start is called before the first frame update
    void Start()
    {
        //�v���C���[�̉摜��ۑ�����
        var player_sprite = GetComponentInParent<SpriteRenderer>().sprite;
        if (player_sprite != null)
        {
            save_sprite_ = player_sprite;
        }

    }

    public override bool enterSkill()
    {
        //�X�L���`���[�W���Ԃ��I����Ă��Ȃ���Δ������Ȃ�
        if (skill_timer_ < SKILL_CHRGE_TIME)
            return false;

        is_active_ = true;

        skill_timer_ = 0.0f;

        //�ϑ��p�摜���Z�b�g
        if(disguise_sprite_ != null)
        {
            GetComponentInParent<SpriteRenderer>().sprite = disguise_sprite_;
        }

        //�e�I�u�W�F�N�g�̎擾����(�v���C���[�I�u�W�F�N�g)
        var parent_object = transform.root.gameObject;

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
        //�ϑ����ɃZ�b�g�����摜�����ɖ߂�
        if (save_sprite_ != null)
        {
            GetComponentInParent<SpriteRenderer>().sprite = save_sprite_;
        }

        //�e�I�u�W�F�N�g�̎擾����(�v���C���[�I�u�W�F�N�g)
        var parent_object = transform.root.gameObject;
        parent_object.layer = LayerMask.NameToLayer("Player");

        disguise_timer_ = 0.0f;
    }
}
