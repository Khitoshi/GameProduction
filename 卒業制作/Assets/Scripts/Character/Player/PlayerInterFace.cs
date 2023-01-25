using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  //SceneManager���g�p����̂ɕK�v

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
        die,
        delete, //���g�̍폜�X�e�[�g
        game_clear,
    }


    public PlayerMove player_move_;
    public PlayerTrapMove player_trap_move;
    public PlayerFieldOfView player_fov;
    private PLAYER_STATE player_act;
    private PlayerSkill player_skill_;
    private void Start()
    {
        player_move_ = GetComponent<PlayerMove>();
        player_trap_move = GetComponent<PlayerTrapMove>();
        if (player_fov != null)
            player_fov = GetComponentInChildren<PlayerFieldOfView>();
        is_life = true;

        player_act = PLAYER_STATE.idle;

        //�I�u�W�F�N�g�ɃA�^�b�`���Ă��Ȃ��X�N���v�g��GetComponent���Ă�null�ƂȂ�
        switch (PlayerPrefs.GetInt("THIS_SKILL"))
        {
            case (int)PlayerSkill.PLAYER_SKILL_LABEL.none:
                player_skill_ = GetComponentInChildren<PlayerSkill>();
                break;

            case (int)PlayerSkill.PLAYER_SKILL_LABEL.dash:
                player_skill_ = GetComponentInChildren<DashSkill>();
                break;
        }

    }

    private void Update()
    {

    }

    //�ǐڐG���ɃK�^�c�L�h�~�̈�FixedUpdate���ŏ�������
    //0.02�b���ɌĂ΂��t���[��
    private void FixedUpdate()
    {
    }

    public void playerAction()
    {
        switch (player_act)
        {
            case PLAYER_STATE.idle:
                player_move_.move();
                if (Input.GetButton("Skill"))
                    player_skill_.enterSkill();
                player_skill_.moveSkill();
                break;

            case PLAYER_STATE.move:
                player_move_.move();
                if (Input.GetButton("Skill"))
                    player_skill_.enterSkill();
                player_skill_.moveSkill();
                break;

            case PLAYER_STATE.pitfall:
                player_trap_move.pitfallAct();
                break;
            case PLAYER_STATE.die:
                if (is_life)
                {
                    GameManager.game_staging_controller_.setStaging(GameStagingController.GAME_STAGING_LABEL.game_over);
                    is_life = false;
                }

                //���o���I�������玩�g���폜����X�e�[�g�֑J�ڂ���
                if (!GameManager.game_staging_controller_.is_staging_)
                {
                    transitionDeleteState();
                }
                break;

            case PLAYER_STATE.delete:
                SceneManager.LoadScene("GameOverScene");
                break;
            case PLAYER_STATE.game_clear:
                if (is_life)
                {
                    GameManager.game_staging_controller_.setStaging(GameStagingController.GAME_STAGING_LABEL.game_clear);
                    is_life = false;
                }

                //���o���I�������玩�g���폜����X�e�[�g�֑J�ڂ���
                if (!GameManager.game_staging_controller_.is_staging_)
                {
                    SceneManager.LoadScene("GameClearScene");
                }
                break;
        }

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

    //�G�̓����蔻��
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag != "Enemy") return;
        Debug.Log("die");
        //collision.gameObject.GetComponent<PlayerInterFace>().transitionDieState();
        transitionDieState();
    }
}