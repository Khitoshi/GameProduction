using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageItem : MonoBehaviour
{
    [SerializeField]
    private Text title;

    private StageData stageData;

    public void Setup(StageData stageData)
    {
        title.text = stageData.Name;

        FieldData fieldData = MasterData.FieldDataTable.Find(stageData.FieldId);

        this.stageData = stageData;
    }

    public void Update()
    {
        //Debug.Log(transform.position);
    }

    public void OnClickButton()
    {
        GameManager.StageProgressService.AcceptStage(stageData);
    }
}
