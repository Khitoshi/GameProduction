using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "‘²‹Æ§ì/FiledDataTable", fileName = "FiledDataTable")]
public class FieldDataTable : ScriptableObject
{
    public FieldData[] Fields;
    
    public FieldData Find(int fieldId)
    {
        return Fields.FirstOrDefault(field => field.Id == fieldId);
    }
}

[Serializable]
public class FieldData
{
    public int Id;
    public string Name;
    public string SceneName;
    public Sprite Icon;
}
