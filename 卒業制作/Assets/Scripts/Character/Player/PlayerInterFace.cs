using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMove))]
//�v���C���[����N���X
public class PlayerInterFace : CharacterInterface
{
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

    }

    //�ǐڐG���ɃK�^�c�L�h�~�̈�FixedUpdate���ŏ�������
    //0.02�b���ɌĂ΂��t���[��
    private void FixedUpdate()
    {
        //�ړ��v�Z�����W�֔��f����
        player_move_.move();
    }

}
