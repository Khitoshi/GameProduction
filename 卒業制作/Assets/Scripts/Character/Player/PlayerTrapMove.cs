using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerTrapMove : CharacterMove
{
    public Gauge gauge;
    public TypeKey type_key;
    private PlayerInterFace player;
    public bool gaugePlus;
    public bool is_fall;
    Vector2 pos;

    private void Start()
    {
        player = GetComponent<PlayerInterFace>();
        gaugePlus = false;
        is_fall = false;
    }

    public void pitfallAct()
    {
        is_fall = true;

        //gaugePlus = true;
        //
        //if(gauge.isMaxGauge)
        //{
        //    gaugePlus = false;
        //    gauge.isMaxGauge = false;
        //
        //    PlayerPos();
        //}

        if (type_key.text_finish)
        {
            is_fall = false;

            PlayerPos();
        }


    }

    private void PlayerPos()
    {
        //’âŽ~‚µ‚Ä‚¢‚½player‚ð“®‚©‚·
        player.transitionMoveState();
        Rigidbody2D rigid = player.GetComponent<Rigidbody2D>();
        pos = rigid.position;
        pos += new Vector2(-1.0f, 0.0f);
        rigid.position = pos;
    }
}
