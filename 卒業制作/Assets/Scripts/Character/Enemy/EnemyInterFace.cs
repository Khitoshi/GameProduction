using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyMove))]
public class EnemyInterFace : CharacterInterface
{
    //敵の行動ステート
    private enum  ENEMY_STATE_LABEL
    {
        idle = 0,//待機
        wander,//徘徊
        pursuit,//追跡
    }

    public EnemyMove enemy_move_;   //座標移動
    public EnemyFieldOfView enemy_fov_; //視界
    public EnemyStateMachine enemy_state_machine;
    //private ENEMY_STATE_LABEL enemy_act_;   //行動ステート
    public Transform target_transform_ {private set; get; }   //追跡する目的地
    private void Start()
    {
        enemy_move_ = GetComponent<EnemyMove>();
        enemy_fov_ = GetComponentInChildren<EnemyFieldOfView>();

        //enemy_act_ = ENEMY_STATE_LABEL.idle;

        enemy_fov_.on_field_of_view += transitionPursuitState;
        //視界にいる場合のメソッド
        //enemy_fov_.on_field_of_view += transitionWanderState;

        //視界から消えた(最初からいない)場合のメソッド
        enemy_fov_.exit_field_of_view += transitionWanderState;

        enemy_state_machine = GetComponent<EnemyStateMachine>();
        enemy_state_machine.changeSubState((int)EnemyStateMachine.ENEMY_STATE_LABEL.idle);
        //enemy_state_machine.ChangeState(enemy_state_machine.current_pool_[(int)ENEMY_STATE_LABEL.idle]);
        //enemy_state_machine
        //enemy_state_machine = new EnemyStateMachine();
        //enemy_state_machine.current_state_ = enemy_state_machine.current_pool_[0];
    }

    private void Update()
    {

    }

    //壁接触時にガタツキ防止の為FixedUpdate内で処理する
    private void FixedUpdate()
    {
        enemy_state_machine.execute();
    }

    public void enemyAction()
    {

        //switch (enemy_act_)
        //{
        //    case ENEMY_STATE_LABEL.idle:
        //        /*
        //        enemy_move_.horizonalMove();
        //        enemy_move_.rotationOnlyMove();

        //        //移動計算を座標へ反映する
        //        enemy_move_.move();
        //        */
        //        break;

        //    case ENEMY_STATE_LABEL.wander:
        //        //transform.position = enemy_move_.wander();
        //        transform.position = enemy_move_.wanderMove(transform);
        //        Debug.Log("wander");
        //        break;
        //    case ENEMY_STATE_LABEL.pursuit_player:
        //        //座標を直接操作してるのでmove()関数と競合する

        //        transform.position = enemy_move_.moveToTarget(transform, target_transform_);

        //        break;
        //}

        enemy_state_machine.execute();

    }

    /*
    public void transitionIdleState()
    {
        //enemy_act_ = ENEMY_STATE_LABEL.idle;
        enemy_state_machine.ChangeState(enemy_state_machine.current_pool_[(int)ENEMY_STATE_LABEL.idle]);
    }


    public void transitionWanderState(Collider2D other)
    {
        //enemy_act_ = ENEMY_STATE_LABEL.idle;

        target_transform_ = other.transform;
        enemy_state_machine.ChangeState(enemy_state_machine.current_pool_[(int)ENEMY_STATE_LABEL.wander]);
    }

    //public void transitionPursuitPlayerState(Collider2D other)
    public void transitionPursuitState()
    {
        //enemy_act_ = ENEMY_STATE_LABEL.pursuit_player;
        enemy_state_machine.ChangeState(enemy_state_machine.current_pool_[(int)ENEMY_STATE_LABEL.pursuit]);

        //target_transform_ = other.transform;
        //target_transform_ = gameObject.transform.Find("PlayerTest");
    }

    */
    public void moveToTarget(Vector3 target)
    {
        transform.position = enemy_move_.moveToTarget(transform, target);
    }


    void transitionWanderState()
    {
        GetComponent<EnemyStateMachine>().changeSubState((int)EnemyStateMachine.ENEMY_STATE_LABEL.wander);
    }

    void transitionPursuitState()
    {
        GetComponent<EnemyStateMachine>().changeSubState((int)EnemyStateMachine.ENEMY_STATE_LABEL.pursuit);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag != "Player") return;

        collision.gameObject.GetComponent<PlayerInterFace>().transitionDieState();

    }
}
