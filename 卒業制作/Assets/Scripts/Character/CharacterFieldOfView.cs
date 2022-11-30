using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Experimental.Rendering.Universal;
using System.Collections.ObjectModel;

//�e�L�����N�^�[�I�u�W�F�N�g�̎���p
public class CharacterFieldOfView : MonoBehaviour
{
    //���E�̃A���O��
    [SerializeField] private float angle_;

    //���E�̋���
    private CircleCollider2D circle_collider_;

    //onTriggerStay���Ɏg�p����tag
    private readonly System.Collections.ObjectModel.ReadOnlyCollection<string> trigger_tag_;
    public CharacterFieldOfView(string raycast_mask)
    {
        //onTriggerStay���Ɏg�p����tag
        trigger_tag_ = Array.AsReadOnly<string>(new string[] {raycast_mask});
    }

    //����p�̒��ɂ��邩���肷��
    public bool checkFielOfView(Collider2D other)
    {
        //other���g���K�[�̃^�O���������āA-1��(�Ȃ�)�ꍇ�Ԃ�
        if (!trigger_tag_.Contains(other.tag)) return false;

        //���E�̊p�x���Ɏ��܂��Ă��邩
        //�ڐG�I�u�W�F�N�g�ւ̃x�N�g��
        Vector3 pos_delta = other.transform.position - this.transform.position;
        //�ڐG�I�u�W�F�N�g�̏�����x�N�g��
        Vector3 direction = other.transform.up;

        //�ڐG�I�u�W�F�N�g�̏�����x�N�g������ڐG�I�u�W�F�N�g�����x�N�g���܂ł̊p�x���擾����
        float target_angle = Vector3.Angle(direction, pos_delta);

        //���E�̊p�x���傫���ꍇ�͎���p�O�Ƃ���
        if (target_angle >= angle_)
        {
            return false;
        }

        //���g�̓��C�L���X�g���肵�Ȃ��ׂ̃}�X�N����
        int layer_mask = ~LayerMask.GetMask(LayerMask.LayerToName(this.gameObject.layer));

        //�ڐG�I�u�W�F�N�g�����ւ̃��C�L���X�g����
        RaycastHit2D hit = Physics2D.Raycast(transform.position, pos_delta, circle_collider_.radius, layer_mask);
        if (hit.collider == other)
        {
            //����p���ɓ�����
            return true;
        }
        return false;

        //TODO:�ڐG�I�u�W�F�N�g�����ւ̃x�N�g�����Z�o�A���̃x�N�g���𐳋K��
        //���g�̏�����x�N�g�����擾
        //��L��̃x�N�g����atanf�ɂ��A�p�x�Z�o
        //�Z�o�����p�x������p��菬������Ύ���p�̒��ɂ��锻��ŏ�L�Ɠ��������Ȃ�Ȃ����m�F����

    }

}
