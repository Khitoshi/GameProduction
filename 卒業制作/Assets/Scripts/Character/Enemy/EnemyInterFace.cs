using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyMove))]
public class EnemyInterFace : CharacterInterface
{
    //敵の行動ステート
    private enum  ENEMY_STATE_LABEL
    {
        idle = 0,   //待機
        wander,     //徘徊
        pursuit,    //追跡
    }

    public EnemyMove enemy_move_;   //座標移動
    public EnemyFieldOfView enemy_fov_; //視界
    public EnemyStateMachine enemy_state_machine;
    public int hp_;    //敵のヒットポイント
    public Transform target_transform_ {private set; get; }   //追跡する目的地

    public Vector3 latest_position;

    private void Start()
    {
        enemy_move_ = GetComponent<EnemyMove>();
        enemy_fov_ = GetComponentInChildren<EnemyFieldOfView>();

        //視界にいる場合のメソッド
        enemy_fov_.on_field_of_view += transitionPursuitState;

        //視界から消えた(最初からいない)場合のメソッド
        enemy_fov_.exit_field_of_view += transitionWanderState;

        //pursuit(追跡時用)target position set
        enemy_fov_.set_player_finding_location = GetComponent<EnemyPursuitState>().set_target_positon;

        //最初の state　は　idle
        enemy_state_machine = GetComponent<EnemyStateMachine>();
        enemy_state_machine.changeSubState((int)EnemyStateMachine.ENEMY_STATE_LABEL.idle);

        hp_ = 3;
    }

    private void Update()
    {
        if(hp_ <= 0)
        {
            is_life_ = false;
            Destroy(gameObject, 1.0f);
        }
    }

    //壁接触時にガタツキ防止の為FixedUpdate内で処理する
    private void FixedUpdate()
    {
        //enemy_move_.rotationOnlyMove();
        enemy_state_machine.execute();
    }

    public void enemyAction()
    {
        //enemy_move_.rotationOnlyMove();
        enemy_state_machine.execute();
    }

    void transitionWanderState()
    {
        GetComponent<EnemyStateMachine>().changeSubState((int)EnemyStateMachine.ENEMY_STATE_LABEL.wander);
        enemy_state_machine.changeSubState((int)EnemyStateMachine.ENEMY_STATE_LABEL.wander);
    }

    void transitionPursuitState()
    {
        GetComponent<EnemyStateMachine>().changeSubState((int)EnemyStateMachine.ENEMY_STATE_LABEL.pursuit);
        //GetComponent<EnemyStateMachine>().changeSubState((int)EnemyStateMachine.ENEMY_STATE_LABEL.pursuit);
        enemy_state_machine.changeSubState((int)EnemyStateMachine.ENEMY_STATE_LABEL.pursuit);
    }

    public void subtractHp(int sub)
    {
        hp_ -= sub;
        if (hp_ < 0)
            hp_ = 0;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Wave")
        {
            subtractHp(1);
        }
    }

}
