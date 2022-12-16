using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  //SceneManagerを使用するのに必要

public class SwitchScene : MonoBehaviour
{
    [SerializeField]
    private Button touch_button_;

    [SerializeField]
    private string change_scene_ = null;

    // Start is called before the first frame update
    void Start()
    {
        //タッチボタンがクリックされた時に呼ばれる関数を登録
        touch_button_.onClick.AddListener(OnClickTouchButton);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnClickTouchButton()
    {
        if (!GameManager.fade_service_.isFading())
        {
            //ホーム画面への遷移開始()
            //コルーチンにて実装
            //「処理１」→「一定時間待つ」→「処理２」→「一定時間待つ」→「処理３」
            //コルーチンは、IEnumeratorを返す関数
            //StartCoroutineにて呼び出す
            StartCoroutine(DoTransitionScene());
        }

    }

    private IEnumerator DoTransitionScene()
    {

        if (change_scene_ == null)
        {
            Debug.Log("シーンが設定されていません");
        }

        //フェード開始
        GameManager.fade_service_.fadeOut();


        //コルーチン：数秒後に何か処理を行いたいときや非同期のような処理を作成する
        //フェード完了(isFadingがfalseになるまで)まで待つ
        yield return new WaitUntil(() => !GameManager.fade_service_.isFading());
        
        //画面が真っ黒状態でシーンを遷移する
        SceneManager.LoadScene(change_scene_);
        //フェードイン開始
        GameManager.fade_service_.fadeIn();
    }
}
