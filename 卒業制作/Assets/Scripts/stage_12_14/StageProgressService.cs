using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public delegate void NotifyStageClearHandler(int stageId);
public delegate void NotifyStageStartHandler(int stageId);
public class StageProgressService : MonoBehaviour
{
    private StageProgress acceptedStage;

    public event NotifyStageClearHandler notify_clear;
    public event NotifyStageStartHandler notify_start;

    public void AcceptStage(StageData stageData)
    {
        StartCoroutine(DoAceeptStage(stageData));
    }

    private IEnumerator DoAceeptStage(StageData stageData)
    {
        GameManager.fade_service_.fadeOut();

        yield return new WaitUntil(() => !GameManager.fade_service_.isFading());

        FieldData fieldData = MasterData.FieldDataTable.Find(stageData.FieldId);
        SceneManager.LoadScene(fieldData.SceneName);

        acceptedStage = new StageProgress();
        acceptedStage.StageData = stageData;

        GameManager.fade_service_.fadeIn();

        notify_start?.Invoke(stageData.Id);
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
