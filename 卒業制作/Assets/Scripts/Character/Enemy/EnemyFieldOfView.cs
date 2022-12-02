using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�G�l�~�[�p�̎���p�Ǘ��N���X
public class EnemyFieldOfView : CharacterFieldOfView
{

    public delegate void onFieldOfView(Collider2D other);
    public onFieldOfView on_field_of_view;

    public delegate void exitFieldOfView();
    public exitFieldOfView exit_field_of_view;

    //�R���X�g���N�^(GetComponent�ɂăN���X�𐶐�����鎞�ɂ��R���X�g���N�^�͌Ă΂��)
    //�����̕�����͎���p�����C�L���X�g�������Ώ̂̕����������
    public EnemyFieldOfView() : base("Player")
    {
        
    }

    private void Start()
    {
        circle_collider_ = GetComponent<CircleCollider2D>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(checkFieldOfView(other))
        {
            if (on_field_of_view != null)
            {
                on_field_of_view(other);
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

    private void OnTriggerExit2D(Collider2D other)
    {
        if (exit_field_of_view != null)
        {
            exit_field_of_view();
        }
    }
}
