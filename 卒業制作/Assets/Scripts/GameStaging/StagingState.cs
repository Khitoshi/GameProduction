using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���o�p�̃X�e�[�g
public class StagingState : HierarchicalState
{

    //�R���X�g���N�^
    public StagingState() { }
    //�X�e�[�g�ɓ��������̃��\�b�h
    public override void enter() { base.enter(); }
    //�X�e�[�g�Ŏ��s���郁�\�b�h
    public override void execute() { base.execute(); }
    //�X�e�[�g����o�Ă����Ƃ��̃��\�b�h
    public override void exit() { GameManager.game_staging_controller.setStagingNone(); base.exit(); }
}

