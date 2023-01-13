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

    //ゲーム開始時直後のシーン読込前に呼ばれるようにする属性を指定
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]  //←関数の前にこれを付ける事でゲーム開始時のシーン読込前に呼ばれる
    private static void InitializeBeforeSceneLoad()
    {
        //Resourcesフォルダ内のGameManagerプレハブを読込
        var gameManagerPrefab = Resources.Load<GameManager>("GameManager");

        //ゲーム中に常に存在するオブジェクトを生成
        var gameManager = Instantiate(gameManagerPrefab);
        //シーンの変更時に破棄されないようにする
        DontDestroyOnLoad(gameManager);
        
        //グローバルで利用するためのサービスを設定
        fade_service_ = gameManager.GetComponent<FadeService>();
        game_staging_controller_ = gameManager.GetComponent<GameStagingController>();
        StageProgressService = gameManager.GetComponent<StageProgressService>();


    }
}
