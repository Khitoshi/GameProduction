using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FadeService))]
[RequireComponent(typeof(GameStagingController))]
[RequireComponent(typeof(StageProgressService))]
public class GameManager : MonoBehaviour
{
    public static FadeService fade_service_ { get; private set; }

    public static GameStagingController game_staging_controller_ { get; private set; }

    public static StageProgressService StageProgressService { get; private set; }

    //�Q�[���J�n������̃V�[���Ǎ��O�ɌĂ΂��悤�ɂ��鑮�����w��
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]  //���֐��̑O�ɂ����t���鎖�ŃQ�[���J�n���̃V�[���Ǎ��O�ɌĂ΂��
    private static void InitializeBeforeSceneLoad()
    {
        //Resources�t�H���_����GameManager�v���n�u��Ǎ�
        var gameManagerPrefab = Resources.Load<GameManager>("GameManager");

        //�Q�[�����ɏ�ɑ��݂���I�u�W�F�N�g�𐶐�
        var gameManager = Instantiate(gameManagerPrefab);
        //�V�[���̕ύX���ɔj������Ȃ��悤�ɂ���
        DontDestroyOnLoad(gameManager);
        
        //�O���[�o���ŗ��p���邽�߂̃T�[�r�X��ݒ�
        fade_service_ = gameManager.GetComponent<FadeService>();
        game_staging_controller_ = gameManager.GetComponent<GameStagingController>();
        StageProgressService = gameManager.GetComponent<StageProgressService>();


    }
}
