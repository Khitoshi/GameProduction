using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//第一階層のステート(スター獲得、攻撃等の行動グループ分け)
public class HierarchicalState : StateBase
{
    public List<StateBase> subStatePool;  //2層目ステート配列
    public StateBase subState;              //2層目登録用ステートアドレス
                                           
    //コンストラクタ
    public HierarchicalState() { }
    //ステートに入った時のメソッド
    public virtual void enter() {  }
    //ステートで実行するメソッド
    public virtual void execute() { }
    //ステートから出ていくときのメソッド
    public virtual void exit() { }
    //サブステート登録
    public virtual void setSubState(int newState) { }
    //サブステート変更
    public virtual void changeSubState(int newState) { }
    //サブステート登録
    public virtual void registerSubState(StateBase state) { }
    //サブステート取得
    public virtual StateBase getSubState() { return subState; }

};
