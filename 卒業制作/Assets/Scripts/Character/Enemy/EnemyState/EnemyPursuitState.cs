using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPursuitState : StateBase
{
    
    Vector3 player_postion;
    public override void enter()
    {
        Debug.Log("pursuit start");
        //player_postion = GameObject.Find("PlayerTest").transform.position;
    }

    public override void execute()
    {
        player_postion = GameObject.Find("PlayerTest").transform.position;
        
        GetComponent<EnemyInterFace>().moveToTarget(player_postion);
    }

    public override void exit()
    {
        Debug.Log("Pursuit end");
    }
}
