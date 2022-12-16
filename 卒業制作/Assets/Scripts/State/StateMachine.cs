using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
	// 現在のステート
	public HierarchicalState current_state_ { private set; get; }
	// 各ステートを保持する配列
	public List<HierarchicalState> state_pool_;
	// コンストラクタ
	public StateMachine() { state_pool_ = new List<HierarchicalState>(); }
	// 更新処理
	public void execute() 
	{
		current_state_.execute();
	}
	// ステートセット
	public void setState(int set_state)
	{
		if (state_pool_[set_state] != null)
		{
			current_state_ = state_pool_[set_state];
		}
	}
	//2層目ステートセット
	public void setSubState(int set_substate)
	{
		if (current_state_ != null)
		{
			current_state_.setSubState(set_substate);
		}
	}
	// ステート変更
	public void changeState(int new_state) 
	{
		// 現在のステートのExit関数を実行、新しいステートをセット、新しいステートのEnter関数を呼び出す。
		//1層目ステートのexit関数
		current_state_.exit();
		setState(new_state);
		current_state_.enter();
	}

	// ２層目ステート変更
	public void changeSubState(int new_state) 
	{
		//サブステート切替
		current_state_.changeSubState(new_state);
	}
	// ステート取得
	public HierarchicalState getState() { return current_state_; }

}
