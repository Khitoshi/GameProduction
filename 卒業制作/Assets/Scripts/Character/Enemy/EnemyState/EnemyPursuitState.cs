using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPursuitState : EnemyStateBase
{
    public CircleCollider2D circle_collider;
    //移動先の位置
    private Vector3 move_target_position = new Vector3(0, 0, 0);
    public override void Enter()
    {
        float radius = circle_collider.radius;

        // CircleCollider内のランダムな位置を計算
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
        //移動
        this.gameObject.GetComponent<EnemyInterFace>().MoveToTarget(move_target_position);
        //transform.position
    }

    public override void Exit()
    {
        Debug.Log("Pursuit end");
    }
}
