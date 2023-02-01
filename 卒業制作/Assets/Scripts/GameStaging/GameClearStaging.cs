using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClearStaging : StateBase
{
    public float text_up_time_ = 0.5f;     //テキストの拡大時間

    private float time_ = 0.0f;

    public float max_staging_time_ = 3.0f; //演出の終了時間

    public GameObject text_object_;

    public GameObject canvas_;  //キャンバス

    //コンストラクタ
    public GameClearStaging() { }
    //ステートに入った時のメソッド
    public override void enter()
    {

        //prefabからオブジェクト生成
        text_object_ = Instantiate(text_object_);
        canvas_ = Instantiate(canvas_);
        text_object_.transform.SetParent(canvas_.transform, false);

        //最初は小さく表示する
        Vector3 scale = text_object_.transform.localScale;
        scale = new Vector3(0.1f, 0.1f, 0.1f);
        text_object_.transform.localScale = scale;
        time_ = 0.0f;


    }
    //ステートで実行するメソッド
    public override void execute()
    {
        //文字を拡大表示
        if (time_ < text_up_time_)
        {
            Vector3 scale = text_object_.transform.localScale;
            scale += new Vector3(0.005f, 0.005f, 0.005f);
            if (scale.x <= 1.0f)
                text_object_.transform.localScale = scale;
        }

        //演出時間の終了
        if (time_ > max_staging_time_)
            GameManager.game_staging_controller_.state_machine_.getState().exit();

        time_ += Time.deltaTime;

    }
    //ステートから出ていくときのメソッド
    public override void exit()
    {
        Destroy(text_object_);
        Destroy(canvas_);
    }
}


