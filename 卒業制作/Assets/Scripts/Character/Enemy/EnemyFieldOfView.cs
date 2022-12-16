using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�G�l�~�[�p�̎���p�Ǘ��N���X
public class EnemyFieldOfView : CharacterFieldOfView
{

    //public delegate void onFieldOfView(Collider2D other);
    public delegate void onFieldOfView();
    public onFieldOfView on_field_of_view;//�p�j(pursuit)

    public delegate void exitFieldOfView();
    public exitFieldOfView exit_field_of_view;//�ǐ�(wander)

    public delegate void setPlayerFindingLocation(Vector3 position);
    public setPlayerFindingLocation set_player_finding_location;//�ǐՎ���target position�@set

    //�R���X�g���N�^(GetComponent�ɂăN���X�𐶐�����鎞�ɂ��R���X�g���N�^�͌Ă΂��)
    //�����̕�����͎���p�����C�L���X�g�������Ώ̂̕����������
    public EnemyFieldOfView() : base("Player")
    {
    }

    private void Start()
    {
        circle_collider_ = GetComponent<CircleCollider2D>();
    }

    private void Update()
    {   
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        //�T���Ώۂ̃v���C���[�ȊO�͏��������Ȃ�
        if (other.gameObject.tag == "Player")
        {

            if (checkFieldOfView(other))
            {
                //player�𔭌�������
                if (on_field_of_view != null)
                {
                    set_player_finding_location(other.transform.position);
                    on_field_of_view();
                }
            }

            //���E����������ꍇ
            //else
            //{
            //    if (exit_field_of_view != null)
            //    {
            //        exit_field_of_view();
            //    }
            //}
        }


    }

    private void OnTriggerExit2D(Collider2D other)
    {

        //�T���Ώۂ̃v���C���[�ȊO�͏��������Ȃ�
        if (other.gameObject.tag != "Player")
            return;

        //���E�͈͂���o��̂ō��G(Wander)�ɂ���
        //if (exit_field_of_view != null)
        //{
        //    exit_field_of_view();
        //}
    }
}
