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
    public PlayerSkill this_skill_;
}
