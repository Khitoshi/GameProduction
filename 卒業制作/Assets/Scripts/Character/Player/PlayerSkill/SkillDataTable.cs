using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//�v���C���[�̊e�X�L���o�^�p�f�[�^�e�[�u��
[CreateAssetMenu(menuName = "�v���C���[�X�L��/SkillDataTable", fileName = "SkillDataTable")]
public class SkillDataTable : ScriptableObject
{
    public SkillData[] skill_datas_;
}

[Serializable]
public class SkillData
{
    public PlayerSkill.PLAYER_SKILL_LABEL this_skill_;

    //�A�C�R���摜
    public Sprite skill_image_;

    //�X�L����
    public string skill_name_;

    //�X�L������
    public string skill_information_;

    public SkillData(PlayerSkill.PLAYER_SKILL_LABEL skill, Sprite skill_image, string skill_name, string skill_information)
    {
        this_skill_ = skill;
        skill_image_ = skill_image;
        skill_name_ = skill_name;
        skill_information_ = skill_information;
    }
}
