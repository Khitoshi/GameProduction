using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine:HierarchicalState
{
    public enum ENEMY_STATE_LABEL
    {
        idle = 0,//�ҋ@
        wander,//�p�j
        pursuit,//�ǐ�
    }
}
