using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine:MonoBehaviour
{
    //public EnemyStateBase<CharacterStateBase> current_state_;
    //public List<EnemyStateBase<CharacterStateBase>> current_pool_;
    public EnemyStateBase current_state_;
    public List<EnemyStateBase> current_pool_;


    public void ChangeState(EnemyStateBase state)
    {
        if (current_state_ == state) return;

        if(current_state_ != null) current_state_.Exit();

        //state情報更新
        current_state_ = state;
        Debug.Log("change state"+state);
        current_state_.Enter();
    }


    public void Excute()
    {
        if(current_state_ != null)
        {
            //state 更新
            current_state_.Excute();
        }
    }

}
