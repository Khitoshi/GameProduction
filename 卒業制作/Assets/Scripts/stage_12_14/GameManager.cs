using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StageProgressService))]
//[RequireComponent(typeof(StageRecordService))]
public class GameManager : MonoBehaviour
{
    public static StageProgressService StageProgressService { get; private set;}
    //public static StageRecordService StageRecordService { get; private set; }


    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]

    private static void InitializeBeforeSceneLoad()
    {
        var gameManagerPrefab = Resources.Load<GameManager>("GameManager");

        var gameManager = Instantiate(gameManagerPrefab);


        DontDestroyOnLoad(gameManager);

        StageProgressService = gameManager.GetComponent<StageProgressService>();
        //StageRecordService = gameManager.GetComponent<StageRecordService>();
    }
}
