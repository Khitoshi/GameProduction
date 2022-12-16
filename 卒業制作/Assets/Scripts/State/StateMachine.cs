using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
	// ���݂̃X�e�[�g
	public HierarchicalState current_state_ { private set; get; }
	// �e�X�e�[�g��ێ�����z��
	public List<HierarchicalState> state_pool_;
	// �R���X�g���N�^
	public StateMachine() { state_pool_ = new List<HierarchicalState>(); }
	// �X�V����
	public void execute() 
	{
		current_state_.execute();
	}
	// �X�e�[�g�Z�b�g
	public void setState(int set_state)
	{
		if (state_pool_[set_state] != null)
		{
			current_state_ = state_pool_[set_state];
		}
	}
	//2�w�ڃX�e�[�g�Z�b�g
	public void setSubState(int set_substate)
	{
		if (current_state_ != null)
		{
			current_state_.setSubState(set_substate);
		}
	}
	// �X�e�[�g�ύX
	public void changeState(int new_state) 
	{
		// ���݂̃X�e�[�g��Exit�֐������s�A�V�����X�e�[�g���Z�b�g�A�V�����X�e�[�g��Enter�֐����Ăяo���B
		//1�w�ڃX�e�[�g��exit�֐�
		current_state_.exit();
		setState(new_state);
		current_state_.enter();
	}

	// �Q�w�ڃX�e�[�g�ύX
	public void changeSubState(int new_state) 
	{
		//�T�u�X�e�[�g�ؑ�
		current_state_.changeSubState(new_state);
	}
	// �X�e�[�g�擾
	public HierarchicalState getState() { return current_state_; }

}
