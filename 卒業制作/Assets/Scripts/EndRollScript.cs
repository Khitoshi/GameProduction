using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  //SceneManagerを使用するのに必要

//エンドロール時のテキストスクロール用
public class EndRollScript : MonoBehaviour
{
    //　テキストのスクロールスピード
    [SerializeField]
    private float text_scroll_speed = 30;
    //　テキストの制限位置
    [SerializeField]
    private float text_limit_position = 730f;
    //　エンドロールが終了したかどうか
    private bool is_stop_endroll;
    //　シーン移動用コルーチン
    private Coroutine endroll_coroutine;

    // Update is called once per frame
    void Update()
    {
        //　エンドロールが終了した時
        if (is_stop_endroll)
        {
            endroll_coroutine = StartCoroutine(GoToNextScene());
        }
        else
        {
            //　エンドロール用テキストがリミットを越えるまで動かす
            if (transform.position.y <= text_limit_position)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y + text_scroll_speed * Time.deltaTime);
            }
            else
            {
                is_stop_endroll = true;
            }
        }
    }

    IEnumerator GoToNextScene()
    {
        //　5秒間待つ
        yield return new WaitForSeconds(5f);

        if (Input.GetKeyDown("space"))
        {
            StopCoroutine(endroll_coroutine);
            SceneManager.LoadScene("TitleScene");
        }

        yield return null;
    }
}
