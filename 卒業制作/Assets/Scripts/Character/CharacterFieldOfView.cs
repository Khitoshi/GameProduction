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
    [SerializeField] float search_radian_start = 0.785f;    //0.785f��dgree��45�x
    [SerializeField] float search_radian_end = 2.356f;  //2.356f��dgree��135�x

    //���E�̋���
    protected CircleCollider2D circle_collider_;

    //onTriggerStay���Ɏg�p����tag
    private readonly System.Collections.ObjectModel.ReadOnlyCollection<string> trigger_tag_;
    public CharacterFieldOfView(string raycast_mask)
    {
        //onTriggerStay���Ɏg�p����tag
        trigger_tag_ = Array.AsReadOnly<string>(new string[] { raycast_mask });
    }

    public void Update()
    {
        //���E�̃��C�����f�o�b�O�\���p�̏�����
        float ray_length = 1.0f;

        float offset_angle_radian = transform.parent.localEulerAngles.z;
        offset_angle_radian *= 0.01745f; //rad = dgree * (��/180)

        Vector3 ray_end1 = new Vector3(transform.parent.position.x + Mathf.Cos(search_radian_start + offset_angle_radian) * ray_length, transform.parent.position.y + Mathf.Sin(search_radian_start + offset_angle_radian), transform.position.z);
        Vector3 ray_end2 = new Vector3(transform.parent.position.x + Mathf.Cos(search_radian_end + offset_angle_radian) * ray_length, transform.parent.position.y + Mathf.Sin(search_radian_end + offset_angle_radian), transform.position.z);

        float front_x = Mathf.Cos(offset_angle_radian + 1.5705f);
        float front_y = Mathf.Sin(offset_angle_radian + 1.5705f);
        Vector3 eye_end = new Vector3(transform.parent.position.x + front_x * 2.0f, transform.parent.position.y + front_y * 2.0f, transform.parent.position.z);

        //���E�̃��C�����f�o�b�O�\���p�̏���
        Color line_color = new Color(1.0f, 1.0f, 1.0f);
        Debug.DrawLine(transform.parent.position, eye_end, line_color);
        Debug.DrawLine(transform.parent.position, ray_end1, line_color);
        Debug.DrawLine(transform.parent.position, ray_end2, line_color);

        //�e�I�u�W�F�N�g�̍��W���X�V
        transform.position = transform.parent.position;
    }

    //����p�̒��ɂ��邩���肷��
    public bool checkFieldOfView(Collider2D other)
    {
        //���E�̊p�x���Ɏ��܂��Ă��邩
        //�ڐG�I�u�W�F�N�g�ւ̃x�N�g��
        Vector3 pos_delta = other.transform.position - transform.parent.position;

        //�ڐG�I�u�W�F�N�g�܂ł̃x�N�g���̊p�x���擾����
        float target_angle = Mathf.Atan2(pos_delta.y, pos_delta.x);

        //���g�̉�]�p�x���I�t�Z�b�g�l�Ƃ��Ď�������
        float offset_angle_radian = transform.parent.localEulerAngles.z;
        offset_angle_radian *= 0.01745f; //rad = dgree * (��/180)

        //Atan2��0 ~ 180��, 0 ~ -180�������Z�o���Ȃ��̂�360�����̃��W�A���𑫂��ĕ␳���s��
        if (target_angle < 0.0f)
        {
            target_angle += Mathf.PI * 2;
        }

        //����p��360�x�𒴂���ꍇ�͕␳���s��
        float radian_start = search_radian_start + offset_angle_radian;
        float radian_end = search_radian_end + offset_angle_radian;
        if (radian_start > Mathf.PI * 2)
        {
            radian_start = radian_start - Mathf.PI * 2;
        }

        if (radian_end > Mathf.PI * 2)
        {
            radian_end = radian_end - Mathf.PI * 2;
        }

        //���g����]���Ă���ꍇstart�̊p�x(350�x)�Aend�̊p�x(80�x)�ƂȂ�ꍇ������̂ő΍�Ƃ��ĉ��L�̔�����s��
        if (radian_start < radian_end)
        {
            if (target_angle >= radian_start
                && target_angle <= radian_end)
            {
                return checkTargetRayCast(other);
            }
        }
        else
        {

            //���g�̉�]�p�ɂ����start�̕����傫���Ȃ�ꍇ�͂���Ŋp�x������s��
            if (target_angle >= radian_start)
            {
                //����p���Z�o����
                float diffrence_angle = search_radian_end - search_radian_start;

                //����p�𑫂����p�x�ȓ��Ȃ王��p�̒��ɂ���
                if (target_angle < radian_start + diffrence_angle)
                    return checkTargetRayCast(other);
            }

            //�p�x��360���𒴂���0������ɂȂ�ꍇ�̔���
            else
            {
                //����p��end����0���𒴂������l�ɂȂ��Ă��邩�炻���艺�����肷��
                if (target_angle <= radian_end)
                    return checkTargetRayCast(other);
            }
        }

        //Debug.Log("�p�x" + target_angle / 0.01745f);
        //Debug.Log("S�p�x" + radian_start / 0.01745f);
        //Debug.Log("E�p�x" + radian_end / 0.01745f);
        return false;
    }

    //�^�[�Q�b�g�̊Ԃɑ��̃I�u�W�F�N�g�����������肷��֐�
    public bool checkTargetRayCast(Collider2D other)
    {
        Vector2 mine_position = new Vector2(transform.parent.position.x, transform.parent.position.y);
        Vector2 target_position = new Vector2(other.transform.position.x, other.transform.position.y);

        //���C���΂��������Z�o
        Vector2 direction = target_position - mine_position;

        //���g�̓��C�L���X�g�ΏۂȂ�Ȃ��悤�Ƀ}�X�N����
        int layer_mask = ~LayerMask.GetMask(LayerMask.LayerToName(this.gameObject.layer));

        RaycastHit2D hit = Physics2D.Raycast(mine_position, direction, circle_collider_.radius, layer_mask);
        //RaycastHit2D hit = Physics2D.Raycast(mine_position, direction, circle_collider_.radius);
        if (hit)
        {
            //�f�o�b�O�p�@���C�L���X�g��
            //���C�L���X�g�Ώۂ��q�b�g�R���W�����Ɠ����Ȃ�true(�q�b�g�R���W�����Ώۂ̓R���X�g���N�^���Ɍ��肳��Ă���)
            if (hit.collider.gameObject.tag == other.gameObject.tag)
            {
                Debug.DrawRay(this.transform.position, direction);
                return true;
            }
        }

        return false;
    }
}
