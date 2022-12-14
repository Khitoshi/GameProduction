using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ステージ上の敵を管理するクラス
public class EnemyManager : MonoBehaviour
{
    [SerializeField]
    private List<EnemyInterFace> enemy_lists_;

    public EnemyManager()
    {
        enemy_lists_ = new List<EnemyInterFace>();

        for (int i = 0; i < enemy_lists_.Count; i++)
        {
            //シーンのヒエラルキービューに設定されたプレイヤーオブジェクトを取得する
            enemy_lists_[i] = enemy_lists_[i].GetComponent<EnemyInterFace>();
        }
    }

    public void fixedUpdate()
    {
        for(int i = 0; i < enemy_lists_.Count; i++)
        {
            enemy_lists_[i].enemyAction();
        }
    }

    public void setPosition(int enemy_no, Vector3 set_position)
    {
        if (enemy_lists_[enemy_no] != null)
        {
            enemy_lists_[enemy_no].transform.position = set_position;
        }
    }
}
