using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//回転のみをするステート
public class EnemyRotateState : StateBase
{
    private float time_ = 0.0f;

    private EnemyInterFace enemy_inter_face_;


    public override void enter()
    {
        enemy_inter_face_ = GetComponent<EnemyInterFace>();

        enemy_inter_face_.enemy_move_.walk_animation_ = false;

        time_ = 0.0f;
    
    }

    public override void execute()
    {
        //回転行動のみ
        enemy_inter_face_.enemy_move_.rotationOnlyMove();

        time_ += Time.deltaTime;
    }

    public override void exit()
    {
       
    }
}
