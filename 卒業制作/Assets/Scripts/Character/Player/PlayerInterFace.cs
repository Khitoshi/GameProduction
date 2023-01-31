using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    public Animator animator_;

    //�X�L���`���[�W�pUI�̃L�����o�X�v���t�@�u
    public Canvas skill_charage_canvas_prefab_;

    //�X�L���`���[�W�pUI�̃v���t�@�u���畡���p
    private Canvas skill_charage_canvas_;
    private Image skill_charge_gauge_;
    private Image skill_charge_ui_;
    private RectTransform skill_charge_ui_size_;

    private void Start()
    {
        player_move_ = GetComponent<PlayerMove>();
        player_trap_move = GetComponent<PlayerTrapMove>();
        if (player_fov != null)
            player_fov = GetComponentInChildren<PlayerFieldOfView>();
        is_life_ = true;

        animator_ = GetComponent<Animator>();

        //�X�L���`���[�W�pUI�쐬������
        //�X�L���`���[�WUi�p�̃L�����o�X�쐬
        skill_charage_canvas_ = Instantiate<Canvas>(skill_charage_canvas_prefab_);


        skill_charge_gauge_ = skill_charage_canvas_.transform.GetChild(1).GetComponent<Image>();
        skill_charge_gauge_.sprite = Resources.Load<Sprite>("�X�L���`���[�W�gUI");
        skill_charge_ui_ = skill_charage_canvas_.transform.GetChild(0).GetComponent<Image>();
        skill_charge_ui_.sprite = Resources.Load<Sprite>("�X�L���`���[�WUI");
        skill_charge_ui_size_ = skill_charge_ui_.GetComponent<RectTransform>();

        skill_charge_ui_.type = Image.Type.Filled;
        skill_charge_ui_.fillMethod = Image.FillMethod.Vertical;
        skill_charge_ui_.fillAmount = 0.5f;

        //�X�L���`���[�W�pUI�쐬������

        player_act = PLAYER_STATE.idle;

        //�I�u�W�F�N�g�ɃA�^�b�`���Ă��Ȃ��X�N���v�g��GetComponent���Ă�null�ƂȂ�
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
                if (is_life_)
                {
                    GameManager.game_staging_controller_.setStaging(GameStagingController.GAME_STAGING_LABEL.game_clear);
                    is_life_ = false;
                }

                //���o���I�������玩�g���폜����X�e�[�g�֑J�ڂ���
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

    //�X�L���𔭓��Ɋւ��鏈��
    private void checkSkill()
    {
        //skill_charge_ui_size_.sizeDelta = new Vector2(100.0f, 50.0f);
        if (Input.GetButton("Skill"))
            player_skill_.enterSkill();
        player_skill_.moveSkill();
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