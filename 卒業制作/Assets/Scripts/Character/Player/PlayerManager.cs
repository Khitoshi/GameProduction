using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//プレイヤー管理クラス
public class PlayerManager : MonoBehaviour
{
    
    [SerializeField]
    private PlayerInterFace player_ = null;

    public Vector3 player_pos { get { return player_.transform.position; } }

    public PlayerManager()
    {
        if(player_ != null)
        {
            //シーンのヒエラルキービューに設定されたプレイヤーオブジェクトを取得する
            player_ = player_.GetComponent<PlayerInterFace>();
        }
    }

    public void update()
    {
        if (player_ != null)
            player_.player_move_.inputMove();
    }

    public void fixedUpdate()
    {
        if(player_ != null)
        {
            player_.playerAction();
        }
    }

    public void setPosition(int enemy_no, Vector3 set_position)
    {
        if (player_ != null)
        {
            player_.transform.position = set_position;
        }
    }
}
