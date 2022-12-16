using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "���Ɛ���/StageDataTable",fileName = "StageDataTable")]
public class StageDataTable : ScriptableObject
{
    public StageData[] Stages;
}

[Serializable]
public class StageData
{
    public int Id;
    public string Name;
    public int FieldId;
}
