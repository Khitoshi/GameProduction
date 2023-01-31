using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerTrapMove : CharacterMove
{
    private PlayerInterFace player;
    Vector2 pos;

    //トラップの中にいるか判定する
    public bool is_trap_ = false;

    private void Start()
    {
        player = GetComponent<PlayerInterFace>();
        is_trap_ = false;
    }


    public void PlayerPos()
    {
        //停止していたplayerを動かす
        player.transitionMoveState();
        Rigidbody2D rigid = player.GetComponent<Rigidbody2D>();
        pos = rigid.position;
        pos += new Vector2(-1.0f, 0.0f);
        rigid.position = pos;
    }
}
