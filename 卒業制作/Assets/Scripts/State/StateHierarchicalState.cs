using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���K�w�̃X�e�[�g(�X�^�[�l���A�U�����̍s���O���[�v����)
public class HierarchicalState : StateBase
{
    public List<StateBase> subStatePool;  //2�w�ڃX�e�[�g�z��
    public StateBase subState;              //2�w�ړo�^�p�X�e�[�g�A�h���X
                                           
    //�R���X�g���N�^
    public HierarchicalState() { }
    //�X�e�[�g�ɓ��������̃��\�b�h
    public virtual void enter() {  }
    //�X�e�[�g�Ŏ��s���郁�\�b�h
    public virtual void execute() { }
    //�X�e�[�g����o�Ă����Ƃ��̃��\�b�h
    public virtual void exit() { }
    //�T�u�X�e�[�g�o�^
    public virtual void setSubState(int newState) { }
    //�T�u�X�e�[�g�ύX
    public virtual void changeSubState(int newState) { }
    //�T�u�X�e�[�g�o�^
    public virtual void registerSubState(StateBase state) { }
    //�T�u�X�e�[�g�擾
    public virtual StateBase getSubState() { return subState; }

};
