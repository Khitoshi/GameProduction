using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageItem : MonoBehaviour
{
    [SerializeField]
    private Text title;

    [SerializeField]
    private Image fieldIcon;

    private StageData stageData;

    public void Setup(StageData stageData)
    {
        title.text = stageData.Name;

        FieldData fieldData = MasterData.FieldDataTable.Find(stageData.FieldId);
        fieldIcon.sprite = fieldData.Icon;

        this.stageData = stageData;
    }

    public void OnClickButton()
    {
        GameManager.StageProgressService.AcceptStage(stageData);
    }
}
