using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMove))]
[RequireComponent(typeof(PlayerFieldOfView))]
//�v���C���[����N���X
public class PlayerInterFace : CharacterInterface
{
    public PlayerMove player_move_;
    public PlayerFieldOfView player_fov;
    private void Start()
    {
        player_move_ = GetComponent<PlayerMove>();
        player_fov = GetComponent<PlayerFieldOfView>();
    }

    private void Update()
    {
        //���͂ɂ��ړ����x�v�Z
        player_move_.inputMove();
        //�ړ��v�Z�����W�֔��f����
        player_move_.move();
    }

}
