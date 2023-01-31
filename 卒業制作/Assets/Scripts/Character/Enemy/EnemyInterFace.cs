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
    private Animator animator_;
    public int hp_;    //敵のヒットポイント
    public Transform target_transform_ {private set; get; }   //追跡する目的地

    public Vector3 latest_position;

    //無敵時間
    private float INVISIBLE_TIME = 0.5f;

    //無敵時間カウント用
    private float invisible_time_ = 0.0f;

    //攻撃ヒットフラッグ
    private bool is_hit_ = false;
    public bool is_hit { get { return is_hit_; } set { is_hit_ = value; } }

    //初期のステートを決定する
    public EnemyStateMachine.ENEMY_STATE_LABEL initialize_state_ = EnemyStateMachine.ENEMY_STATE_LABEL.idle;

    private void Start()
    {
        enemy_move_ = GetComponent<EnemyMove>();
        enemy_fov_ = GetComponentInChildren<EnemyFieldOfView>();
        animator_ = GetComponent<Animator>();

        //視界にいる場合のメソッド
        enemy_fov_.on_field_of_view += transitionPursuitState;

        //視界から消えた(最初からいない)場合のメソッド
        enemy_fov_.exit_field_of_view += transitionWanderState;

        //pursuit(追跡時用)target position set
        enemy_fov_.set_player_finding_location = GetComponent<EnemyPursuitState>().set_target_positon;

        //最初の state　は　idle
        enemy_state_machine = GetComponent<EnemyStateMachine>();
        enemy_state_machine.changeSubState((int)initialize_state_);

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

    }

    public void enemyAction()
    {
        //enemy_move_.rotationOnlyMove();
        enemy_state_machine.execute();

        invisibleCount();

        //自身の回転値から前方向ベクトルを求める
        float angle_radian = transform.localEulerAngles.z;

        float power_ang_x = Mathf.Cos(angle_radian);
        float power_ang_y = Mathf.Sin(angle_radian);

        if(Mathf.Abs(power_ang_x) > Mathf.Abs(power_ang_y))
        {
            if(power_ang_x < 0.0f)
            {
                animator_.SetFloat("MoveX", -1.0f);
            }

            else
            {
                animator_.SetFloat("MoveX", 1.0f);
            }
        }

        else
        {
            if (power_ang_y < 0.0f)
            {
                animator_.SetFloat("MoveY", -1.0f);
            }

            else
            {
                animator_.SetFloat("MoveY", 1.0f);
            }
        }
        animator_.SetBool("WalkTrigger", enemy_move_.walk_animation_);
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
        //無敵時間中なら処理しない
        if (is_hit_)
            return;

        hp_ -= sub;
        if (hp_ < 0)
            hp_ = 0;
    }

    //無敵時間計算用
    public void invisibleCount()
    {
        if(is_hit_)
        {
            if(invisible_time_ > INVISIBLE_TIME)
            {
                is_hit_ = false;
                invisible_time_ = 0.0f;
                return;
            }

            else
            {
                invisible_time_ += Time.deltaTime;
            }

        }
    }


}
