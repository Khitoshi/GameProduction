using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�G�l�~�[�p�̎���p�Ǘ��N���X
public class EnemyFieldOfView : CharacterFieldOfView
{

    //public delegate void onFieldOfView(Collider2D other);
    public delegate void onFieldOfView();
    public onFieldOfView on_field_of_view;//pursuit

    public delegate void exitFieldOfView();
    public exitFieldOfView exit_field_of_view;//wander

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
        //wander
        //GetComponent<EnemyStateMachine>().changeSubState((int)EnemyStateMachine.ENEMY_STATE_LABEL.wander);
        
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
                    //is_trigger = true;
                    on_field_of_view();
                }
            }

            //���E����������ꍇ
            else
            {
                if (exit_field_of_view != null)
                {
                    exit_field_of_view();
                }
            }
            
        }


    }

    private void OnTriggerExit2D(Collider2D other)
    {

        //�T���Ώۂ̃v���C���[�ȊO�͏��������Ȃ�
        if (other.gameObject.tag != "Player")
            return;

        //���E�͈͂���o��̂ō��G(Wander)�ɂ���
        if (exit_field_of_view != null)
        {
            exit_field_of_view();
        }
    }
}
