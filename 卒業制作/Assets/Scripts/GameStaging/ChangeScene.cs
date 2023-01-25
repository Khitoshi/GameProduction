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
        // ���݂̃V�[���擾
        Scene scene = SceneManager.GetActiveScene();

        // ���݂̃V�[���̃r���h�ԍ��擾
        int build_index = scene.buildIndex;

        // ���݂̃V�[���̃r���h�ԍ��Ɂ@+1
        build_index += 1;
        
        // �擾�����r���h�ԍ��̃V�[����ǂݍ���
        SceneManager.LoadScene(build_index);

        // �Z�[�u���ꂽ�f�[�^�̓ǂݍ���
        //LordData();

    }


    private void ClearData()
    {
        // ���݂̃V�[���擾���A�r���h�ԍ����擾
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
