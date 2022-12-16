using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : StateBase
{
    private float time_ = 0.0f;

    public float max_staging_time_ = 3.0f; //�ҋ@�̏I������
    public override void enter()
    {
        time_ = 0.0f;
        Debug.Log("Idle start");
    }

    public override void execute()
    {
        //wander�Ɉړ�
        //�ҋ@���Ԃ̏I��
        if (time_ > max_staging_time_)
        {
            Debug.Log(time_);
            GetComponent<EnemyStateMachine>().changeSubState((int)EnemyStateMachine.ENEMY_STATE_LABEL.wander);
        }
        //Debug.Log("time:" + time_);
        time_ += Time.deltaTime;
    }

    public override void exit()
    {
        Debug.Log("Idle end");
    }
}
