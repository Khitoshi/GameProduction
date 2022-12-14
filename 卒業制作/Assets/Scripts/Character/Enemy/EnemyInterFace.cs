using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyMove))]
public class EnemyInterFace : CharacterInterface
{
    //�G�̍s���X�e�[�g
    private enum  ENEMY_STATE_LABEL
    {
        idle = 0,//�ҋ@
        wander,//�p�j
        pursuit,//�ǐ�
    }

    public EnemyMove enemy_move_;   //���W�ړ�
    public EnemyFieldOfView enemy_fov_; //���E
    public EnemyStateMachine enemy_state_machine;
    //private ENEMY_STATE_LABEL enemy_act_;   //�s���X�e�[�g
    public Transform target_transform_ {private set; get; }   //�ǐՂ���ړI�n
    private void Start()
    {
        enemy_move_ = GetComponent<EnemyMove>();
        enemy_fov_ = GetComponentInChildren<EnemyFieldOfView>();

        //enemy_act_ = ENEMY_STATE_LABEL.idle;

        //enemy_fov_.on_field_of_view += transitionPursuitPlayerState;
        //���E�ɂ���ꍇ�̃��\�b�h
        enemy_fov_.on_field_of_view += transitionWanderState;

        //���E���������(�ŏ����炢�Ȃ�)�ꍇ�̃��\�b�h
        enemy_fov_.exit_field_of_view += transitionPursuitState;

        enemy_state_machine = GetComponent<EnemyStateMachine>();
        enemy_state_machine.ChangeState(enemy_state_machine.current_pool_[(int)ENEMY_STATE_LABEL.idle]);
        //enemy_state_machine = new EnemyStateMachine();
        //enemy_state_machine.current_state_ = enemy_state_machine.current_pool_[0];
    }

    private void Update()
    {

    }

    //�ǐڐG���ɃK�^�c�L�h�~�̈�FixedUpdate���ŏ�������
    private void FixedUpdate()
    {
        enemyAction();
    }

    private void enemyAction()
    {

        //switch (enemy_act_)
        //{
        //    case ENEMY_STATE_LABEL.idle:
        //        /*
        //        enemy_move_.horizonalMove();
        //        enemy_move_.rotationOnlyMove();

        //        //�ړ��v�Z�����W�֔��f����
        //        enemy_move_.move();
        //        */
        //        break;

        //    case ENEMY_STATE_LABEL.wander:
        //        //transform.position = enemy_move_.wander();
        //        transform.position = enemy_move_.wanderMove(transform);
        //        Debug.Log("wander");
        //        break;
        //    case ENEMY_STATE_LABEL.pursuit_player:
        //        //���W�𒼐ڑ��삵�Ă�̂�move()�֐��Ƌ�������

        //        transform.position = enemy_move_.moveToTarget(transform, target_transform_);

        //        break;
        //}

        enemy_state_machine.Excute();

    }

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

    public void MoveToTarget(Vector3 target)
    {
        transform.position = enemy_move_.moveToTarget(transform, target);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag != "Player") return;

        collision.gameObject.GetComponent<PlayerInterFace>().transitionDieState();

    }
}
