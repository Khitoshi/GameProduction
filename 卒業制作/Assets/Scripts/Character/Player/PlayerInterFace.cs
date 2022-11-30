using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMove))]
[RequireComponent(typeof(PlayerFieldOfView))]
//プレイヤー制御クラス
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
        //入力による移動速度計算
        player_move_.inputMove();
        //移動計算を座標へ反映する
        player_move_.move();
    }

}
