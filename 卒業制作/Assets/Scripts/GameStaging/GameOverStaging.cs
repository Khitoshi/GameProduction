using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverStaging : StateBase
{
    public StagingObject staging_object_;

    private float text_up_time_;     //テキストの拡大時間

    private float time_ = 0.0f;

    public GameObject text_object_;

    //コンストラクタ
    public GameOverStaging(StagingObject staging) { staging_object_ = staging; }
    //ステートに入った時のメソッド
    public void enter()
    {
        text_up_time_ = 0.5f;

        //prefabからオブジェクト生成
        text_object_ = Instantiate(staging_object_.objects_[0]);

        //最初は小さく表示する
        Vector3 scale = text_object_.transform.localScale;
        scale = new Vector3(0.1f, 0.1f, 0.1f);
        text_object_.transform.localScale = scale;

        //画面中央に出現
        text_object_.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, 0);

    }
    //ステートで実行するメソッド
    public void execute() 
    {
        //文字を拡大表示
        if(time_ < text_up_time_)
        {
            Vector3 scale = text_object_.transform.localScale;
            scale += new Vector3(0.1f, 0.1f, 0.1f);
            text_object_.transform.localScale = scale;
        }

        //演出時間の終了
        if (time_ > staging_object_.max_staging_time)
            this.exit();

        time_ += Time.deltaTime;

    }
    //ステートから出ていくときのメソッド
    public void exit() 
    {
        Destroy(text_object_);
    }
}
