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
            // �V�[���`�F���W
            ChengeScene();


            // �f�[�^�ۑ�
            ClearData();
        }
    }

    private void ChengeScene()
    {
        SceneManager.LoadScene("Stage_Select");
    }


    private void ClearData()
    {
        // ���݂̃V�[���擾���A�r���h�ԍ����擾
        Scene scene = SceneManager.GetActiveScene();
        int scene_index = scene.buildIndex;

        PlayerPrefs.SetInt("ClearStage", 1);
       
    }

    private void LordData()
    {
        PlayerPrefs.GetInt("ClearStage");
    }
}
