using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMove))]
//�v���C���[����N���X
public class PlayerInterFace : CharacterInterface
{
    private enum PLAYER_STATE
    {
        idle = 0,
        move = 1,
        pitfall = 2,//���Ƃ����Ƀn�}���Ă���
        stealth = 3,//���̉��Ȃǂɂ���
    }


    public PlayerMove player_move_;
    public PlayerFieldOfView player_fov;
    private PLAYER_STATE player_act;
    private void Start()
    {
        player_move_ = GetComponent<PlayerMove>();
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
                break;

            case PLAYER_STATE.stealth:
                player_move_.move();
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

    public void transitionStealthState()
    {
        player_act = PLAYER_STATE.stealth;
        //TODO:�V�����N���X������ā@move�ȂǂƓ����悤�ȏ��������
        this.gameObject.layer = LayerMask.NameToLayer("Stealth");
    }

}
