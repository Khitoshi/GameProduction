using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWanderState : EnemyStateBase
{
    private Vector3 target_position;
    public override void Enter()
    {
        Debug.Log("Wander start");
    }

    public override void Excute()
    {
        target_position = this.gameObject.GetComponent<EnemyInterFace>().target_transform_.position;
        this.gameObject.GetComponent<EnemyInterFace>().MoveToTarget(target_position);
    }

    public override void Exit()
    {
        Debug.Log("Wander end");
    }
}
