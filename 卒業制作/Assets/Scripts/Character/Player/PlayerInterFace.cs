using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMove))]
[RequireComponent(typeof(PlayerTrapMove))]
//�v���C���[����N���X
public class PlayerInterFace : CharacterInterface
{
    private enum PLAYER_STATE
    {
        idle = 0,
        move = 1,
        pitfall = 2,
    }


    public PlayerMove player_move_;
    public PlayerTrapMove player_trap_move;
    public PlayerFieldOfView player_fov;
    private PLAYER_STATE player_act;
    private void Start()
    {
        player_move_ = GetComponent<PlayerMove>();
        player_trap_move = GetComponent<PlayerTrapMove>();
        player_fov = GetComponentInChildren<PlayerFieldOfView>();

        player_act = PLAYER_STATE.idle;
    }

    private void Update()
    {

        player_move_.inputMove();

    }

    //�ǐڐG���ɃK�^�c�L�h�~�̈�FixedUpdate���ŏ�������
    //0.02�b���ɌĂ΂��t���[��
    private void FixedUpdate()
    {
        playerAction();
    }

    private void playerAction()
    {
        switch(player_act)
        {
            case PLAYER_STATE.idle:
                player_move_.move();
                break;

            case PLAYER_STATE.move:
                player_move_.move();
                break;

            case PLAYER_STATE.pitfall:
                player_trap_move.pitfallAct();
                break;
        }
    }

    public void transitionIdleState()
    {
        player_act = PLAYER_STATE.idle;
    }

    public void transitionMoveState()
    {
        player_act = PLAYER_STATE.move;
    }

    public void transitionPitfallState()
    {
        player_act = PLAYER_STATE.pitfall;
    }
}
