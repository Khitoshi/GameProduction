using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//�X�L���A�C�R���摜�Ȃǂ̏����󂯎��ݒ�A�\���Ɋւ��鐧�䂷��N���X
public class ProcessingSkillSlot : MonoBehaviour
{
    //���g�̃X�L���f�[�^�i�[�p
    public SkillData my_skill_data_;

    //�@�A�C�e���̃f�[�^���Z�b�g
    public void setSkillData(SkillData skill_data)
    {
        my_skill_data_ = skill_data;
        //�A�C�R���̃X�v���C�g��ݒ�
        transform.GetChild(0).GetComponent<Image>().sprite = my_skill_data_.skill_image_;
    }

    //�J�[�\�������g�֌������Ă��鎞���̐�������̃N���X�ōs��
}
