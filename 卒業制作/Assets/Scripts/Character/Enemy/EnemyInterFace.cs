using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyMove))]
public class EnemyInterFace : CharacterInterface
{
    //敵の行動ステート
    private enum  ENEMY_STATE_LABEL
    {
        idle = 0,
        pursuit_player = 1,
    }

    public EnemyMove enemy_move_;   //座標移動
    public EnemyFieldOfView enemy_fov_; //視界
    private ENEMY_STATE_LABEL enemy_act_;   //行動ステート
    private Transform target_transform_;   //追跡する目的地
    private void Start()
    {
        enemy_move_ = GetComponent<EnemyMove>();
        enemy_fov_ = GetComponentInChildren<EnemyFieldOfView>();

        enemy_act_ = ENEMY_STATE_LABEL.idle;

        enemy_fov_.on_field_of_view += transitionPursuitPlayerState;
        enemy_fov_.exit_field_of_view += transitionIdleState;

    }

    private void Update()
    {

    }

    //壁接触時にガタツキ防止の為FixedUpdate内で処理する
    private void FixedUpdate()
    {
        enemyAction();
    }

    private void enemyAction()
    {
        switch (enemy_act_)
        {
            case ENEMY_STATE_LABEL.idle:
                enemy_move_.horizonalMove();
                enemy_move_.rotationOnlyMove();

                //移動計算を座標へ反映する
                enemy_move_.move();
                break;

            case ENEMY_STATE_LABEL.pursuit_player:
                //座標を直接操作してるのでmove()関数と競合する
                transform.position = enemy_move_.moveToTarget(transform, target_transform_);

                break;
        }

    }

    public void transitionIdleState()
    {
        enemy_act_ = ENEMY_STATE_LABEL.idle;
    }

    public void transitionPursuitPlayerState(Collider2D other)
    {
        enemy_act_ = ENEMY_STATE_LABEL.pursuit_player;
        target_transform_ = other.transform;
    }
}
