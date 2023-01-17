using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//プレイヤーの各スキル登録用データテーブル
[CreateAssetMenu(menuName = "プレイヤースキル/SkillDataTable", fileName = "SkillDataTable")]
public class SkillDataTable : ScriptableObject
{
    public SkillData[] skill_datas_;
}

[Serializable]
public class SkillData
{
    public PlayerSkill this_skill_;
}
