using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterData : MonoBehaviour
{
   public static FieldDataTable FieldDataTable { get; private set; }

   public static StageDataTable StageDataTable { get; private set; }

    [SerializeField]
    private FieldDataTable fieldData;

    [SerializeField]
    private StageDataTable stageData;

    public void Awake()
    {
        FieldDataTable = fieldData;
        StageDataTable = stageData;
    }
}
