using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyMove))]
public class EnemyInterFace : CharacterInterface
{
    //�G�̍s���X�e�[�g
    private enum  ENEMY_STATE_LABEL
    {
        idle = 0,
        pursuit_player = 1,
    }

    public EnemyMove enemy_move_;   //���W�ړ�
    public EnemyFieldOfView enemy_fov_; //���E
    private ENEMY_STATE_LABEL enemy_act_;   //�s���X�e�[�g
    private Transform target_transform_;   //�ǐՂ���ړI�n
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

    //�ǐڐG���ɃK�^�c�L�h�~�̈�FixedUpdate���ŏ�������
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

                //�ړ��v�Z�����W�֔��f����
                enemy_move_.move();
                break;

            case ENEMY_STATE_LABEL.pursuit_player:
                //���W�𒼐ڑ��삵�Ă�̂�move()�֐��Ƌ�������
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
