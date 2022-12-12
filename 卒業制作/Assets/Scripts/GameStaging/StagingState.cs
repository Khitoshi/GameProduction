using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//演出用のステート
public class StagingState : HierarchicalState
{

    //コンストラクタ
    public StagingState() { }
    //ステートに入った時のメソッド
    public override void enter() { base.enter(); }
    //ステートで実行するメソッド
    public override void execute() { base.execute(); }
    //ステートから出ていくときのメソッド
    public override void exit() { GameManager.game_staging_controller.setStagingNone(); base.exit(); }
}

