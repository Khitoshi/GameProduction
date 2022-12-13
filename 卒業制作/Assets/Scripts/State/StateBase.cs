using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//任意の動作を実行するStateクラス
public class StateBase : MonoBehaviour
{
	// コンストラクタ
	public StateBase() { }
	// ステートに入った時のメソッド
	public virtual void enter() { }
	// ステートで実行するメソッド
	public virtual void execute() { }
	// ステートから出ていくときのメソッド
	public virtual void exit() { }
};

