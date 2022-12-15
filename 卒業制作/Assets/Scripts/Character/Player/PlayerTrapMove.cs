using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerTrapMove : CharacterMove
{
    public Gauge gauge;
    private PlayerInterFace player;
    public bool gaugePlus;
    Vector2 pos;

    private void Start()
    {
        player = GetComponent<PlayerInterFace>();
        gaugePlus = false;
    }

    public void pitfallAct()
    {
        gaugePlus = true;
        
        if(gauge.isMaxGauge)
        {
            gaugePlus = false;
            gauge.isMaxGauge = false;

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
