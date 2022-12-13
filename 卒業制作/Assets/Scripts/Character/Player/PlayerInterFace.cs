using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMove))]
//�v���C���[����N���X
public class PlayerInterFace : CharacterInterface
{
    private enum PLAYER_STATE_LABEL
    {
        idle = 0,
        die,
    }
    private PLAYER_STATE_LABEL player_act_;   //�s���X�e�[�g

    public PlayerMove player_move_;
    public PlayerFieldOfView player_fov;

    private void Start()
    {
        player_move_ = GetComponent<PlayerMove>();
        player_fov = GetComponentInChildren<PlayerFieldOfView>();
        is_life = true;
    }

    private void Update()
    {
        //���͂ɂ��ړ����x�v�Z
        player_move_.inputMove();

        //���Ńv���C���[���E������������
        /*
        if(Input.GetKey("up"))
        {
            if (is_life != false)
            {
                GameManager.game_staging_controller.setStaging(GameStagingController.GAME_STAGING_LABEL.game_over);
                GameManager.game_staging_controller.state_machine_.setState((int)GameStagingController.GAME_STAGING_LABEL.game_over);
                GameManager.game_staging_controller.state_machine_.setSubState((int)GameStagingController.GAME_STAGING_LABEL.game_over);
                is_life = false;
            }
        }
        */
    }

    //�ǐڐG���ɃK�^�c�L�h�~�̈�FixedUpdate���ŏ�������
    //0.02�b���ɌĂ΂��t���[��
    private void FixedUpdate()
    {
        switch (player_act_)
        {
            case PLAYER_STATE_LABEL.idle:
                player_move_.move();
                break;

            case PLAYER_STATE_LABEL.die:
                //���W�𒼐ڑ��삵�Ă�̂�move()�֐��Ƌ�������
                //transform.position = enemy_move_.moveToTarget(transform, target_transform_);
                if(is_life)
                {
                    Destroy(gameObject, 5.0f);
                    GameManager.game_staging_controller.setStaging(GameStagingController.GAME_STAGING_LABEL.game_over);
                    GameManager.game_staging_controller.state_machine_.setState((int)GameStagingController.GAME_STAGING_LABEL.game_over);
                    GameManager.game_staging_controller.state_machine_.setSubState((int)GameStagingController.GAME_STAGING_LABEL.game_over);
                    is_life = false;
                }
                break;
        }

        //�ړ��v�Z�����W�֔��f����
    }

    public void SetPlayerStateLabel_Die()
    {
        player_act_ = PLAYER_STATE_LABEL.die;
    }


}
