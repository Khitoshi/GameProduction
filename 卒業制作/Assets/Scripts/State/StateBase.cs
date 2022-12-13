using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�C�ӂ̓�������s����State�N���X
public class StateBase : MonoBehaviour
{
	// �R���X�g���N�^
	public StateBase() { }
	// �X�e�[�g�ɓ��������̃��\�b�h
	public virtual void enter() { }
	// �X�e�[�g�Ŏ��s���郁�\�b�h
	public virtual void execute() { }
	// �X�e�[�g����o�Ă����Ƃ��̃��\�b�h
	public virtual void exit() { }
};

