using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//�X�L���A�C�R���摜�Ȃǂ̏����󂯎��ݒ�A�\���Ɋւ��鐧�䂷��N���X
public class ProcessingSkillSlot : MonoBehaviour
{
    //���g�̃X�L���f�[�^�i�[�p
    public SkillData my_skill_data_;

    //���g�Ƀ}�E�X���ڐG���Ă��邩�̔���p
    private bool on_mouse_point_ = false;
    public bool getOnMouse() { return on_mouse_point_; }

    //�@�A�C�e���̃f�[�^���Z�b�g
    public void setSkillData(SkillData skill_data)
    {
        my_skill_data_ = skill_data;
        //�A�C�R���̃X�v���C�g��ݒ�(icon�̎q�I�u�W�F�N�g�̏��ԏ��ɐݒ肵�Ă���)
        transform.GetChild(0).GetComponent<Image>().sprite = my_skill_data_.skill_image_;
        transform.GetChild(1).GetComponent<Text>().text = my_skill_data_.skill_name_;
        transform.GetChild(1).GetComponent<Text>().enabled = false;     //���g���I������Ă��Ȃ����͕�����\�����Ȃ��ׂɃe�L�X�g�R���|�[�l���g���A�N�e�B�u�ɂ��Ă���
        transform.GetChild(2).GetComponent<Text>().text = my_skill_data_.skill_information_;
        transform.GetChild(2).GetComponent<Text>().enabled = false;     ////���g���I������Ă��Ȃ����͕�����\�����Ȃ��ׂɃe�L�X�g�R���|�[�l���g���A�N�e�B�u�ɂ��Ă���
    }

    //�J�[�\�������g�֌������Ă��鎞���̐�������̃N���X�ōs��

    //���g�̃A�C�R���̏�Ƀ}�E�X������(Event Trigger�R���|�[�l���g��Pointer Enter�ɐݒ肷��)
    public void onMousePoint()
    {
        //���g���I������Ă����ԂȂ̂ŕ����̕\�����s��
        transform.GetChild(1).GetComponent<Text>().enabled = true;
        transform.GetChild(2).GetComponent<Text>().enabled = true;
        on_mouse_point_ = true;
    }

    //���g�̃A�C�R���̏ォ��}�E�X�����ꂽ(Event Trigger�R���|�[�l���g��Pointer Exit�ɐݒ肷��)
    public void exitMousePoint()
    {
        //���g���I������Ă��Ȃ���ԂɂȂ����̂ŕ������\���ɂ���
        transform.GetChild(1).GetComponent<Text>().enabled = false;
        transform.GetChild(2).GetComponent<Text>().enabled = false;
        on_mouse_point_ = false;
    }
}
