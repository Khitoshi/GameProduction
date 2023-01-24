using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterData : MonoBehaviour
{
   public static FieldDataTable FieldDataTable { get; private set; }

   public static StageDataTable StageDataTable { get; private set; }

    //プレイヤーのスキルデータ管理
    public static SkillDataTable skill_data_table_ { get; private set; }

    [SerializeField]
    private FieldDataTable fieldData;

    [SerializeField]
    private StageDataTable stageData;

    //プレイヤーのスキルデータ管理
    [SerializeField]
    private SkillDataTable skill_data_;

    public void Awake()
    {
        FieldDataTable = fieldData;
        StageDataTable = stageData;
    }
}
