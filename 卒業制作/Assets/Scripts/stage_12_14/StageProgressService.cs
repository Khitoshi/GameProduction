using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageProgressService : MonoBehaviour
{
    private StageProgress acceptedStage;

    public void AcceptStage(StageData stageData)
    {
        FieldData fieldData = MasterData.FieldDataTable.Find(stageData.FieldId);
        SceneManager.LoadScene(fieldData.SceneName);

        acceptedStage = new StageProgress();
        acceptedStage.StageData = stageData;
    }

    public void FinishStage()
    {
        acceptedStage = null;

        SceneManager.LoadScene("Temp_12_14");
    }

    // Update is called once per frame
    void Update()
    {
        if(acceptedStage != null && Input.GetMouseButtonDown(0))
        {
            FinishStage();
        }
    }
}

public class StageProgress
{
    public StageData StageData { get; set; }

    public int Progress { get; set; }
}
