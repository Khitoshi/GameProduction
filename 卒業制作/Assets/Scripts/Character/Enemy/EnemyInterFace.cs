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
    private Vector3 target_position_;   //追跡する目的地
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
                break;

            case ENEMY_STATE_LABEL.pursuit_player:
                transform.position = enemy_move_.moveToTarget(transform.position, target_position_);

                break;
        }

        //移動計算を座標へ反映する
        enemy_move_.move();
    }

    public void transitionIdleState()
    {
        enemy_act_ = ENEMY_STATE_LABEL.idle;
    }

    public void transitionPursuitPlayerState(Collider2D other)
    {
        enemy_act_ = ENEMY_STATE_LABEL.pursuit_player;
        target_position_ = other.transform.position;
    }
}
