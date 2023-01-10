using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : StateBase
{
    private float time_ = 0.0f;

    public float max_staging_time_ = 3.0f; //待機の終了時間

    private EnemyInterFace enemy_inter_face_;

    public override void enter()
    {
        enemy_inter_face_ = GetComponent<EnemyInterFace>();

        time_ = 0.0f;
        Debug.Log("Idle start");
    }

    public override void execute()
    {
        //待機時間の終了
        if (time_ > max_staging_time_)
        {
            //徘徊に状態変更
            enemy_inter_face_.enemy_state_machine.changeSubState((int)EnemyStateMachine.ENEMY_STATE_LABEL.wander);
        }

        time_ += Time.deltaTime;
    }

    public override void exit()
    {
        Debug.Log("Idle end");
    }
}
