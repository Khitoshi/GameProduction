using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collsion)
    {
        if (collsion.gameObject.tag == "Player")
        {
            // シーンチェンジ
            ChengeScene();


            // データ保存
            ClearData();
        }
    }

    private void ChengeScene()
    {
        SceneManager.LoadScene("Stage_Select");
    }


    private void ClearData()
    {
        // 現在のシーン取得し、ビルド番号も取得
        Scene scene = SceneManager.GetActiveScene();
        int scene_index = scene.buildIndex;

        PlayerPrefs.SetInt("ClearStage", 1);
       
    }

    private void LordData()
    {
        PlayerPrefs.GetInt("ClearStage");
    }
}
