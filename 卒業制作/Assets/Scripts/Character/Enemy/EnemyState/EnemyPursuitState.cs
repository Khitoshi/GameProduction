using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPursuitState : EnemyStateBase
{
    public CircleCollider2D circle_collider;
    //�ړ���̈ʒu
    private Vector3 move_target_position = new Vector3(0, 0, 0);
    public override void Enter()
    {
        float radius = circle_collider.radius;

        // CircleCollider���̃����_���Ȉʒu���v�Z
        move_target_position = Random.insideUnitCircle * radius;
        Debug.Log("Pursuit start");
    }

    public override void Excute()
    {
        
        if (transform.position == move_target_position)
        {
            this.gameObject.GetComponent<EnemyInterFace>().transitionIdleState();
        }
        Debug.Log("target" + move_target_position);
        //�ړ�
        this.gameObject.GetComponent<EnemyInterFace>().MoveToTarget(move_target_position);
        //transform.position
    }

    public override void Exit()
    {
        Debug.Log("Pursuit end");
    }
}
