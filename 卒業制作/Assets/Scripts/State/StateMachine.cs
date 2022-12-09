using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
	// 現在のステート
	private HierarchicalState current_state_;
	// 各ステートを保持する配列
	List<HierarchicalState> state_pool_;
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
		current_state_ = state_pool_[set_state];
		current_state_.enter();
	}
	// ステート変更
	public void changeState(int new_state) 
	{
		// 現在のステートのExit関数を実行、新しいステートをセット、新しいステートのEnter関数を呼び出す。
		//現在実行されているサブステートのExit関数を実行
		current_state_.getSubState().exit();

		//1層目ステートのexit関数
		current_state_.exit();
		setState(new_state);
	}
	// ステート登録
	public void registerState(HierarchicalState state) 
	{
		// 親ステート登録
		state_pool_.Add(state);
	}

	// ２層目ステート変更
	public void changeSubState(int new_state) 
	{
		//サブステート切替
		current_state_.changeSubState(new_state);
	}
	// ２層目ステート登録
	public void registerSubState(int index, StateBase sub_state) 
	{

		//サブステート登録
		state_pool_[index].registerSubState(sub_state);
	}
	// ステート取得
	public HierarchicalState getState() { return current_state_; }

}
