using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyStateBase
{
    private float time_ = 0.0f;

    public float max_staging_time_ = 3.0f; //���o�̏I������
    public override void Enter()
    {
        time_ = 0.0f;
        Debug.Log("Idle start");
    }

    public override void Excute()
    {
        //�ҋ@���Ԃ̏I��
        if (time_ > max_staging_time_)
            this.gameObject.GetComponent<EnemyInterFace>().transitionPursuitState();

        time_ += Time.deltaTime;
    }

    public override void Exit()
    {
        Debug.Log("Idle end");
    }
}
