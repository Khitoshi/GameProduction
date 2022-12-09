using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMove))]
//プレイヤー制御クラス
public class PlayerInterFace : CharacterInterface
{
    public PlayerMove player_move_;
    public PlayerFieldOfView player_fov;
    private void Start()
    {
        player_move_ = GetComponent<PlayerMove>();
        player_fov = GetComponentInChildren<PlayerFieldOfView>();
    }

    private void Update()
    {
        //入力による移動速度計算
        player_move_.inputMove();

        //仮でプレイヤーを殺す処理を実装
        if(Input.GetKey("up"))
        {
            GameManager.game_staging_controller.setStaging(GameStagingController.GAME_STAGING_LABEL.game_over);
        }

    }

    //壁接触時にガタツキ防止の為FixedUpdate内で処理する
    //0.02秒毎に呼ばれるフレーム
    private void FixedUpdate()
    {
        //移動計算を座標へ反映する
        player_move_.move();
    }

}
