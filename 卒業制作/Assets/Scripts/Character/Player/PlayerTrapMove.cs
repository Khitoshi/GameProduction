using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerTrapMove : CharacterMove
{
    private PlayerInterFace player;
    Vector2 pos;

    //�g���b�v�̒��ɂ��邩���肷��
    public bool is_trap_ = false;

    private void Start()
    {
        player = GetComponent<PlayerInterFace>();
        is_trap_ = false;
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
