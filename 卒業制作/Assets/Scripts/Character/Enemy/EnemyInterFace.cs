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
    public int hp_;    //�G�̃q�b�g�|�C���g
    public Transform target_transform_ {private set; get; }   //�ǐՂ���ړI�n

    public Vector3 latest_position;

    private void Start()
    {
        enemy_move_ = GetComponent<EnemyMove>();
        enemy_fov_ = GetComponentInChildren<EnemyFieldOfView>();

        //���E�ɂ���ꍇ�̃��\�b�h
        enemy_fov_.on_field_of_view += transitionPursuitState;

        //���E���������(�ŏ����炢�Ȃ�)�ꍇ�̃��\�b�h
        enemy_fov_.exit_field_of_view += transitionWanderState;

        //pursuit(�ǐՎ��p)target position set
        enemy_fov_.set_player_finding_location = GetComponent<EnemyPursuitState>().set_target_positon;

        //�ŏ��� state�@�́@idle
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

    //�ǐڐG���ɃK�^�c�L�h�~�̈�FixedUpdate���ŏ�������
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
