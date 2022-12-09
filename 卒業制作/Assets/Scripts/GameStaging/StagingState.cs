using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//演出用のステート
public class StagingState : HierarchicalState
{

    //コンストラクタ
    public StagingState() { }
    //ステートに入った時のメソッド
    public virtual void enter() { Debug.Log("W"); }
    //ステートで実行するメソッド
    public virtual void execute() { }
    //ステートから出ていくときのメソッド
    public virtual void exit() { GameManager.game_staging_controller.setStagingNone(); }
}

