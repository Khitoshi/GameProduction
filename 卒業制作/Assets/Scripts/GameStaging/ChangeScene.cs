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
        // 現在のシーン取得
        Scene scene = SceneManager.GetActiveScene();

        // 現在のシーンのビルド番号取得
        int build_index = scene.buildIndex;

        // 現在のシーンのビルド番号に　+1
        build_index += 1;
        
        // 取得したビルド番号のシーンを読み込む
        SceneManager.LoadScene(build_index);

        // セーブされたデータの読み込み
        //LordData();

    }


    private void ClearData()
    {
        // 現在のシーン取得し、ビルド番号も取得
        Scene scene = SceneManager.GetActiveScene();
        int scene_index = scene.buildIndex;
        scene_index += 1;

        switch(scene_index)
        {
            case 3:
                PlayerPrefs.SetInt("ClearStage", 3);
                break;

            case 4:
                PlayerPrefs.SetInt("ClearStage", 4);
                break;
        } 
    }

    private void LordData()
    {
        PlayerPrefs.GetInt("ClearStage");
    }
}
