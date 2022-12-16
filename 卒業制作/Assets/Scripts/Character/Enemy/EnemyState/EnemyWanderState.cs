using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWanderState : StateBase
{
    public CircleCollider2D circle_collider;

    //�ړ���̈ʒu
    private Vector3 target_position_;

    private EnemyInterFace enemy_inter_face;

    public override void enter()
    {
        float radius = circle_collider.radius;

        enemy_inter_face = GetComponent<EnemyInterFace>();

        // CircleCollider���̃����_���Ȉʒu���v�Z
        target_position_ = Random.insideUnitCircle * radius;
        Debug.Log("Wander start");
    }

    public override void execute()
    {
        if (transform.position == target_position_)
        {        
            enemy_inter_face.enemy_state_machine.changeSubState((int)EnemyStateMachine.ENEMY_STATE_LABEL.idle);
        }
        else
        {
            //��]
            enemy_inter_face.enemy_move_.rotationOnlyMove(target_position_);
            //�ړ�
            transform.position = enemy_inter_face.enemy_move_.moveToTarget(transform, target_position_);
        }
    }

    public override void exit()
    {
        Debug.Log("Wander end");
    }
}
