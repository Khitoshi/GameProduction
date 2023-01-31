using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerTrapMove : CharacterMove
{
    private PlayerInterFace player;
    Vector2 pos;

    //ƒgƒ‰ƒbƒv‚Ì’†‚É‚¢‚é‚©”»’è‚·‚é
    public bool is_trap_ = false;

    private void Start()
    {
        player = GetComponent<PlayerInterFace>();
        is_trap_ = false;
    }


    public void PlayerPos()
    {
        //’âŽ~‚µ‚Ä‚¢‚½player‚ð“®‚©‚·
        player.transitionMoveState();
        Rigidbody2D rigid = player.GetComponent<Rigidbody2D>();
        pos = rigid.position;
        pos += new Vector2(-1.0f, 0.0f);
        rigid.position = pos;
    }
}
