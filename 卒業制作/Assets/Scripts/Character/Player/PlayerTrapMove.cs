using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerTrapMove : CharacterMove
{
    private PlayerInterFace player;
    Vector2 pos;
    private TypeKey type_key_;
    public TypeKey type_key { set { type_key_ = value; } }

    //�g���b�v�̒��ɂ��邩���肷��
    public bool is_trap_ = false;
    
    private void Start()
    {
        player = GetComponent<PlayerInterFace>();
        is_trap_ = false;
    }

    public void pitfallAct()
    {
        if (is_trap_)
        {

            if (type_key_.text_finish)
            {
                is_trap_ = false;

                //���Ƃ����ɓ���O�֍��W��ύX
                PlayerPos();

            }
        }


    }

    public void PlayerPos()
    {
        //��~���Ă���player�𓮂���
        player.transitionMoveState();
        Rigidbody2D rigid = player.GetComponent<Rigidbody2D>();
        pos = rigid.position;
        pos += new Vector2(-1.0f, 0.0f);
        rigid.position = pos;
    }
}
