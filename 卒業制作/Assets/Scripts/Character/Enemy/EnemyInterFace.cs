using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyMove))]
public class EnemyInterFace : CharacterInterface
{
    //�G�̍s���X�e�[�g
    private enum  ENEMY_STATE_LABEL
    {
        idle = 0,   //�ҋ@
        wander,     //�p�j
        pursuit,    //�ǐ�
    }

    public EnemyMove enemy_move_;   //���W�ړ�
    public EnemyFieldOfView enemy_fov_; //���E
    public EnemyStateMachine enemy_state_machine;
    private Animator animator_;
    public int hp_;    //�G�̃q�b�g�|�C���g
    public Transform target_transform_ {private set; get; }   //�ǐՂ���ړI�n

    public Vector3 latest_position;

    //���G����
    private float INVISIBLE_TIME = 0.5f;

    //���G���ԃJ�E���g�p
    private float invisible_time_ = 0.0f;

    //�U���q�b�g�t���b�O
    private bool is_hit_ = false;
    public bool is_hit { get { return is_hit_; } set { is_hit_ = value; } }

    //�����̃X�e�[�g�����肷��
    public EnemyStateMachine.ENEMY_STATE_LABEL initialize_state_ = EnemyStateMachine.ENEMY_STATE_LABEL.idle;

    private void Start()
    {
        enemy_move_ = GetComponent<EnemyMove>();
        enemy_fov_ = GetComponentInChildren<EnemyFieldOfView>();
        animator_ = GetComponent<Animator>();

        //���E�ɂ���ꍇ�̃��\�b�h
        enemy_fov_.on_field_of_view += transitionPursuitState;

        //���E���������(�ŏ����炢�Ȃ�)�ꍇ�̃��\�b�h
        enemy_fov_.exit_field_of_view += transitionWanderState;

        //pursuit(�ǐՎ��p)target position set
        enemy_fov_.set_player_finding_location = GetComponent<EnemyPursuitState>().set_target_positon;

        //�ŏ��� state�@�́@idle
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

    //�ǐڐG���ɃK�^�c�L�h�~�̈�FixedUpdate���ŏ�������
    private void FixedUpdate()
    {

    }

    public void enemyAction()
    {
        //enemy_move_.rotationOnlyMove();
        enemy_state_machine.execute();

        invisibleCount();

        //���g�̉�]�l����O�����x�N�g�������߂�
        float angle_radian = transform.localEulerAngles.z + 90;

        float power_ang_x = Mathf.Cos(angle_radian);
        float power_ang_y = Mathf.Sin(angle_radian);

        angle_radian *= 0.01745f; //rad = dgree * (��/180)

        //����p��360�x�𒴂���ꍇ�͕␳���s��
        if (angle_radian > Mathf.PI * 2)
        {
            angle_radian = 0.0f;
        }

        //�E��(0.785rad = 45��)
        if (angle_radian < 0.785f)
        {
            animator_.SetFloat("MoveX", 1.0f);
            animator_.SetFloat("MoveY", 0.0f);

        }

        //�㑤(2.356rad = 135��)
        else if (angle_radian < 2.356f)
        {
            animator_.SetFloat("MoveX", 0.0f);
            animator_.SetFloat("MoveY", 1.0f);
        }

        //����(3.926rad = 225��)
        else if (angle_radian < 3.926f)
        {
            animator_.SetFloat("MoveX", -1.0f);
            animator_.SetFloat("MoveY", 0.0f);
        }

        //����(5.497rad = 315��)
        else if (angle_radian < 5.497f)
        {
            animator_.SetFloat("MoveX", 0.0f);
            animator_.SetFloat("MoveY", -1.0f);
        }

        //�E��(5.497rad = 315��)
        else if (angle_radian >= 5.497f)
        {
            animator_.SetFloat("MoveX", 1.0f);
            animator_.SetFloat("MoveY", 0.0f);
        }
        animator_.SetBool("WalkTrigger", enemy_move_.walk_animation_);

        Debug.Log(angle_radian / 0.01745f);
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
        //���G���Ԓ��Ȃ珈�����Ȃ�
        if (is_hit_)
            return;

        hp_ -= sub;
        if (hp_ < 0)
            hp_ = 0;
    }

    //���G���Ԍv�Z�p
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
