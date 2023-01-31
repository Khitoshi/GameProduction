using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPursuitState : StateBase
{
    //追跡するtargetのposition
    Vector3 target_postion_;

    EnemyInterFace enemy_inter_face_;

    //変移先のステートを設定
    public EnemyStateMachine.ENEMY_STATE_LABEL change_state_ = EnemyStateMachine.ENEMY_STATE_LABEL.idle;


    public override void enter()
    {
        enemy_inter_face_ = GetComponent<EnemyInterFace>();


        //Debug.Log("pursuit start");
    }

    public override void execute()
    {
        //playerの最終発見位置までついていない場合
        if(transform.position != target_postion_)
        {

            //移動
            transform.position = enemy_inter_face_.enemy_move_.moveToTarget(this.transform, target_postion_);
        }
        else
        {
            //徘徊へ状態変更
            enemy_inter_face_.enemy_state_machine.changeSubState((int)change_state_);
        }

    }

    public override void exit()
    {
        //Debug.Log("Pursuit end");
    }

    //追跡するtargetのpositionをset
    public void set_target_positon(Vector3 position)
    {
        target_postion_ = position;
    }

}
