using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class EnemyWanderState : StateBase
{
    public CircleCollider2D circle_collider;

    //移動先の位置
    private Vector3 target_position_;

    private EnemyInterFace enemy_inter_face;

    public Light2D light;

    public override void enter()
    {
        float radius = circle_collider.radius;

        enemy_inter_face = GetComponent<EnemyInterFace>();

        //light = GetComponent<Light2D>();

        // CircleCollider内のランダムな位置を計算
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
            //回転
            //enemy_inter_face.enemy_move_.rotationOnlyMove(target_position_);
            //Vector3 dir = (target_position_ - light.transform.position);
            //light.transform.rotation = Quaternion.FromToRotation(Vector3.up, dir);
            //移動
            transform.position = enemy_inter_face.enemy_move_.moveToTarget(transform, target_position_);
        }
    }

    public override void exit()
    {
        Debug.Log("Wander end");
    }
}
