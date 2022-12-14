using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMove))]
[RequireComponent(typeof(PlayerTrapMove))]
//プレイヤー制御クラス
public class PlayerInterFace : CharacterInterface
{
    private enum PLAYER_STATE
    {
        idle = 0,
        move = 1,
        pitfall = 2,
        die,
        game_clear,
    }


    public PlayerMove player_move_;
    public PlayerTrapMove player_trap_move;
    public PlayerFieldOfView player_fov;
    private PLAYER_STATE player_act;
    private void Start()
    {
        player_move_ = GetComponent<PlayerMove>();
        player_trap_move = GetComponent<PlayerTrapMove>();
        if (player_fov != null)
            player_fov = GetComponentInChildren<PlayerFieldOfView>();
        is_life = true;

        player_act = PLAYER_STATE.idle;

    }

    private void Update()
    {

        player_move_.inputMove();

    }

    //壁接触時にガタツキ防止の為FixedUpdate内で処理する
    //0.02秒毎に呼ばれるフレーム
    private void FixedUpdate()
    {
        playerAction();
    }

    private void playerAction()
    {
        switch (player_act)
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
            case PLAYER_STATE.die:
                if (is_life)
                {
                    Destroy(gameObject, 5.0f);
                    GameManager.game_staging_controller_.setStaging(GameStagingController.GAME_STAGING_LABEL.game_over);
                    GameManager.game_staging_controller_.state_machine_.setState((int)GameStagingController.GAME_STAGING_LABEL.game_over);
                    GameManager.game_staging_controller_.state_machine_.setSubState((int)GameStagingController.GAME_STAGING_LABEL.game_over);
                    is_life = false;
                }
                break;
            case PLAYER_STATE.game_clear:
                if(is_life)
                {
                    GameManager.game_staging_controller_.setStaging(GameStagingController.GAME_STAGING_LABEL.game_clear);
                    GameManager.game_staging_controller_.state_machine_.setState((int)GameStagingController.GAME_STAGING_LABEL.game_clear);
                    GameManager.game_staging_controller_.state_machine_.setSubState((int)GameStagingController.GAME_STAGING_LABEL.game_clear);
                    is_life = false;
                }
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

    public void transitionDieState()
    {
        player_act = PLAYER_STATE.die;
    }

    public void transitionGameClearState()
    {
        player_act = PLAYER_STATE.game_clear;
    }

}