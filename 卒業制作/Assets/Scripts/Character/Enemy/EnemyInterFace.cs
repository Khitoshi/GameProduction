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
    //private ENEMY_STATE_LABEL enemy_act_;   //行動ステート
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
    }

    private void Update()
    {

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
        
        enemy_state_machine.changeSubState((int)EnemyStateMachine.ENEMY_STATE_LABEL.wander);
    }

    void transitionPursuitState()
    {
        //GetComponent<EnemyStateMachine>().changeSubState((int)EnemyStateMachine.ENEMY_STATE_LABEL.pursuit);
        enemy_state_machine.changeSubState((int)EnemyStateMachine.ENEMY_STATE_LABEL.pursuit);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //TODO:このメソッド専用のクラスを作りそこに入れる
        if (collision.transform.tag != "Player" || this.transform.tag != "Enemy") return;
        Debug.Log("die");
        collision.gameObject.GetComponent<PlayerInterFace>().transitionDieState();
    }
}
