using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
	// ���݂̃X�e�[�g
	private HierarchicalState current_state_;
	// �e�X�e�[�g��ێ�����z��
	List<HierarchicalState> state_pool_;
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
		current_state_ = state_pool_[set_state];
		current_state_.enter();
	}
	// �X�e�[�g�ύX
	public void changeState(int new_state) 
	{
		// ���݂̃X�e�[�g��Exit�֐������s�A�V�����X�e�[�g���Z�b�g�A�V�����X�e�[�g��Enter�֐����Ăяo���B
		//���ݎ��s����Ă���T�u�X�e�[�g��Exit�֐������s
		current_state_.getSubState().exit();

		//1�w�ڃX�e�[�g��exit�֐�
		current_state_.exit();
		setState(new_state);
	}
	// �X�e�[�g�o�^
	public void registerState(HierarchicalState state) 
	{
		// �e�X�e�[�g�o�^
		state_pool_.Add(state);
	}

	// �Q�w�ڃX�e�[�g�ύX
	public void changeSubState(int new_state) 
	{
		//�T�u�X�e�[�g�ؑ�
		current_state_.changeSubState(new_state);
	}
	// �Q�w�ڃX�e�[�g�o�^
	public void registerSubState(int index, StateBase sub_state) 
	{

		//�T�u�X�e�[�g�o�^
		state_pool_[index].registerSubState(sub_state);
	}
	// �X�e�[�g�擾
	public HierarchicalState getState() { return current_state_; }

}
