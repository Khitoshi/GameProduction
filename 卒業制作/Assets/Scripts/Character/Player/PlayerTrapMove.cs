using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerTrapMove : CharacterMove
{
    private PlayerInterFace player;
    Vector2 pos;
    public TypeKey type_key_;

    //トラップの中にいるか判定する
    public bool is_trap_ = false;
    public bool is_fall_;

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

                //落とし穴に入る前へ座標を変更
                PlayerPos();

            }
        }


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
