using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWanderState : StateBase
{
    public CircleCollider2D circle_collider;
    //移動先の位置
    private Vector3 move_target_position = new Vector3(0, 0, 0);
    public override void enter()
    {
        float radius = circle_collider.radius;

        // CircleCollider内のランダムな位置を計算
        move_target_position = Random.insideUnitCircle * radius;
        Debug.Log("Wander start");
    }

    public override void execute()
    {
        if (transform.position == move_target_position)
        {
            GetComponent<EnemyStateMachine>().changeSubState((int)EnemyStateMachine.ENEMY_STATE_LABEL.idle);
        }
        else
        {
            //Debug.Log(move_target_position);
            //transform.position += ;
           GetComponent<EnemyInterFace>().moveToTarget(move_target_position);
                //moveToTarget(this.transform, move_target_position);
        }
    }

    public override void exit()
    {
        Debug.Log("Wander end");
    }
}
