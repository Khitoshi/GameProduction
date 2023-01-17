using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    [SerializeField]
    private Button stageButton;

    [SerializeField]
    private GameObject stageBorad;
    
    [SerializeField]
    private Button uiBlocker;
    
    [SerializeField]
    private Transform stageItemParent;
    
    [SerializeField]
    private StageItem stageItemPrefab;

    private int lord_data = 0;

    void Start()
    {
        stageButton.onClick.AddListener(OnClickStageButton);

        uiBlocker.onClick.AddListener(OnClickUIBlocker);

       
    }

    private void OnClickStageButton()
    {
        stageBorad.SetActive(true);

        uiBlocker.gameObject.SetActive(true);

       

        bool exist = PlayerPrefs.HasKey("ClearStage");
        if(exist)
        {
            Debug.Log("ë∂ç›Ç∑ÇÈ");

            SceneManager.LoadScene("Stage_4");
        }
        else
        {
            Debug.Log("ë∂ç›ÇµÇ»Ç¢");

            foreach (StageData stageData in MasterData.StageDataTable.Stages)
            {
                StageItem stageItem = Instantiate(stageItemPrefab, stageItemParent);
                stageItem.Setup(stageData);
            }
        }
    }

    private void OnClickUIBlocker()
    {
        stageBorad.SetActive(false);

        uiBlocker.gameObject.SetActive(false);

        foreach(Transform trans in stageItemParent)
        {
            Destroy(trans.gameObject);
        }
    }


}
