using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  //SceneManagerを使用するのに必要

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
        delete, //自身の削除ステート
        game_clear,
    }


    public PlayerMove player_move_;
    public PlayerTrapMove player_trap_move;
    public PlayerFieldOfView player_fov;
    private PLAYER_STATE player_act;
    private PlayerSkill player_skill_;
    private Animator animator_;
    private void Start()
    {
        player_move_ = GetComponent<PlayerMove>();
        player_trap_move = GetComponent<PlayerTrapMove>();
        if (player_fov != null)
            player_fov = GetComponentInChildren<PlayerFieldOfView>();
        is_life_ = true;

        animator_ = GetComponent<Animator>();

        player_act = PLAYER_STATE.idle;

        //オブジェクトにアタッチしていないスクリプトはGetComponentしてもnullとなる
        switch (PlayerPrefs.GetInt(PlayerSkillRecording.SKILL_HASH_KEY))
        {
            case (int)PlayerSkill.PLAYER_SKILL_LABEL.none:
                player_skill_ = GetComponentInChildren<PlayerSkill>();
                break;

            case (int)PlayerSkill.PLAYER_SKILL_LABEL.dash:
                player_skill_ = GetComponentInChildren<DashSkill>();
                break;

            case (int)PlayerSkill.PLAYER_SKILL_LABEL.disguise:
                player_skill_ = GetComponentInChildren<DisguiseSkill>();
                break;


            case (int)PlayerSkill.PLAYER_SKILL_LABEL.wave:
                player_skill_ = GetComponentInChildren<WaveSkill>();
                break;
        }

    }

    private void Update()
    {

    }

    //壁接触時にガタツキ防止の為FixedUpdate内で処理する
    //0.02秒毎に呼ばれるフレーム
    private void FixedUpdate()
    {
    }

    public void playerAction()
    {
        switch (player_act)
        {
            case PLAYER_STATE.idle:
                player_move_.move();
                checkSkill();
                break;

            case PLAYER_STATE.move:
                player_move_.move();
                checkSkill();
                break;

            case PLAYER_STATE.pitfall:
                player_trap_move.pitfallAct();
                break;
            case PLAYER_STATE.die:
                if (is_life_)
                {
                    GameManager.game_staging_controller_.setStaging(GameStagingController.GAME_STAGING_LABEL.game_over);
                    is_life_ = false;
                }

                //演出が終了したら自身を削除するステートへ遷移する
                if (!GameManager.game_staging_controller_.is_staging_)
                {
                    transitionDeleteState();
                }
                break;

            case PLAYER_STATE.delete:
                SceneManager.LoadScene("GameOverScene");
                break;
            case PLAYER_STATE.game_clear:
                if (is_life_)
                {
                    GameManager.game_staging_controller_.setStaging(GameStagingController.GAME_STAGING_LABEL.game_clear);
                    is_life_ = false;
                }

                //演出が終了したら自身を削除するステートへ遷移する
                if (!GameManager.game_staging_controller_.is_staging_)
                {
                    SceneManager.LoadScene("GameClearScene");
                }
                break;
        }

        animator_.SetFloat("MoveX", Mathf.Cos(player_move_.direction_angle_));
        animator_.SetFloat("MoveY", Mathf.Sin(player_move_.direction_angle_));
        animator_.SetBool("WalkTrigger", player_move_.walk_animation_);
        player_skill_.skillChargeTimer();
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

    public void transitionDeleteState()
    {
        player_act = PLAYER_STATE.delete;
    }

    public void transitionGameClearState()
    {
        player_act = PLAYER_STATE.game_clear;
    }

    //スキルを発動に関する処理
    private void checkSkill()
    {
        if (Input.GetButton("Skill"))
            player_skill_.enterSkill();
        player_skill_.moveSkill();
    }

    //敵の当たり判定
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag != "Enemy") return;
        Debug.Log("die");
        //collision.gameObject.GetComponent<PlayerInterFace>().transitionDieState();
        transitionDieState();
    }
}