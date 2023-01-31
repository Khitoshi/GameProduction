using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���K�w�̃X�e�[�g
public class HierarchicalState : StateBase
{
    public List<StateBase> sub_state_pool_;  //2�w�ڃX�e�[�g�z��

    // ���݂̃X�e�[�g
    protected StateBase current_state_;

    //�R���X�g���N�^
    public HierarchicalState() { sub_state_pool_ = new List<StateBase>(); }
    //�X�e�[�g�ɓ��������̃��\�b�h
    public virtual void enter() { current_state_.enter(); }
    //�X�e�[�g�Ŏ��s���郁�\�b�h
    public virtual void execute() { current_state_.execute(); }
    //�X�e�[�g����o�Ă����Ƃ��̃��\�b�h
    public virtual void exit() { current_state_.exit(); }
    //�T�u�X�e�[�g�o�^
    public void setSubState(int new_state)
    {
        if (sub_state_pool_[new_state] == null) return;
        if(current_state_ != sub_state_pool_[new_state])
        {
            current_state_ = sub_state_pool_[new_state];
            current_state_.enter();
        }
    }
    //�T�u�X�e�[�g�ύX
    public void changeSubState(int new_state)
    {
        if (current_state_ == sub_state_pool_[new_state]) return;

        if (current_state_ != null)
            current_state_.exit();
        setSubState(new_state);
    }

};
