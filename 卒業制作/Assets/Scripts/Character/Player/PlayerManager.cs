using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�v���C���[�Ǘ��N���X
public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private PlayerInterFace player_ = null;

    public PlayerManager()
    {
        if(player_ != null)
        {
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
