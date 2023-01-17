using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPursuitState : StateBase
{
    //’ÇÕ‚·‚étarget‚Ìposition
    Vector3 target_postion_;

    EnemyInterFace enemy_inter_face_;


    public override void enter()
    {
        enemy_inter_face_ = GetComponent<EnemyInterFace>();


        Debug.Log("pursuit start");
    }

    public override void execute()
    {
        //player‚ÌÅI”­Œ©ˆÊ’u‚Ü‚Å‚Â‚¢‚Ä‚¢‚È‚¢ê‡
        if(transform.position != target_postion_)
        {

            //ˆÚ“®
            transform.position = enemy_inter_face_.enemy_move_.moveToTarget(this.transform, target_postion_);
        }
        else
        {
            //œpœj‚Öó‘Ô•ÏX
            enemy_inter_face_.enemy_state_machine.changeSubState((int)EnemyStateMachine.ENEMY_STATE_LABEL.idle);
        }

    }

    public override void exit()
    {
        Debug.Log("Pursuit end");
    }

    //’ÇÕ‚·‚étarget‚Ìposition‚ğset
    public void set_target_positon(Vector3 position)
    {
        target_postion_ = position;
    }

}
