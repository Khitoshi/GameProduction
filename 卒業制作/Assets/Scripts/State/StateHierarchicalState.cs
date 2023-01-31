using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//第一階層のステート
public class HierarchicalState : StateBase
{
    public List<StateBase> sub_state_pool_;  //2層目ステート配列

    // 現在のステート
    protected StateBase current_state_;

    //コンストラクタ
    public HierarchicalState() { sub_state_pool_ = new List<StateBase>(); }
    //ステートに入った時のメソッド
    public virtual void enter() { current_state_.enter(); }
    //ステートで実行するメソッド
    public virtual void execute() { current_state_.execute(); }
    //ステートから出ていくときのメソッド
    public virtual void exit() { current_state_.exit(); }
    //サブステート登録
    public void setSubState(int new_state)
    {
        if (sub_state_pool_[new_state] == null) return;
        if(current_state_ != sub_state_pool_[new_state])
        {
            current_state_ = sub_state_pool_[new_state];
            current_state_.enter();
        }
    }
    //サブステート変更
    public void changeSubState(int new_state)
    {
        if (current_state_ == sub_state_pool_[new_state]) return;

        if (current_state_ != null)
            current_state_.exit();
        setSubState(new_state);
    }

};
