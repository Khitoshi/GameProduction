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
    private Button deleteButton;

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
        // 
        stageButton.onClick.AddListener(OnClickStageButton);

        uiBlocker.onClick.AddListener(OnClickUIBlocker);

        deleteButton.onClick.AddListener(OnClickDeleteButton);

    }

    private void OnClickStageButton()
    {

        stageBorad.SetActive(true);

        uiBlocker.gameObject.SetActive(true);

        foreach (StageData stageData in MasterData.StageDataTable.Stages)
        {
            StageItem stageItem = Instantiate(stageItemPrefab, stageItemParent);
            stageItem.Setup(stageData);
        }

        bool exist = PlayerPrefs.HasKey("ClearStage");
        
        // キーを持っているかの判断
        if (exist)
        {
            Debug.Log("存在する");

            // 読み込む
            int lode_scene = PlayerPrefs.GetInt("ClearStage");

            //　セーブされたシーンの番号で次からのシーンを反映する
            switch (lode_scene)
            {
                case 3:
                    SceneManager.LoadScene("Stage_2");
                    Debug.Log("セーブされてシーン移動した  2");
                    break;

                case 4:
                    SceneManager.LoadScene("Stage_4");
                    Debug.Log("セーブされてシーン移動した  4");
                    break;

            }        
        }
        else
        {
            Debug.Log("存在しない");
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

    private void OnClickDeleteButton()
    {
        PlayerPrefs.DeleteAll();

        Debug.Log("データは削除された");

    }
}
