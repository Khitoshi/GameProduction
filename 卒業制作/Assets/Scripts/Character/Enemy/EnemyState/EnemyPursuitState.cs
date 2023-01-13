using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPursuitState : StateBase
{
    //�ǐՂ���target��position
    Vector3 target_postion_;

    EnemyInterFace enemy_inter_face_;


    public override void enter()
    {
        enemy_inter_face_ = GetComponent<EnemyInterFace>();


        Debug.Log("pursuit start");
    }

    public override void execute()
    {
        //player�̍ŏI�����ʒu�܂ł��Ă��Ȃ��ꍇ
        if(transform.position != target_postion_)
        {

            //�ړ�
            transform.position = enemy_inter_face_.enemy_move_.moveToTarget(this.transform, target_postion_);
        }
        else
        {
            //�p�j�֏�ԕύX
            enemy_inter_face_.enemy_state_machine.changeSubState((int)EnemyStateMachine.ENEMY_STATE_LABEL.idle);
        }

    }

    public override void exit()
    {
        Debug.Log("Pursuit end");
    }

    //�ǐՂ���target��position��set
    public void set_target_positon(Vector3 position)
    {
        target_postion_ = position;
    }

}
