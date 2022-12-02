using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//エネミー用の視野角管理クラス
public class EnemyFieldOfView : CharacterFieldOfView
{

    public delegate void onFieldOfView(Collider2D other);
    public onFieldOfView on_field_of_view;

    public delegate void exitFieldOfView();
    public exitFieldOfView exit_field_of_view;

    //コンストラクタ(GetComponentにてクラスを生成される時にもコンストラクタは呼ばれる)
    //引数の文字列は視野角がレイキャストしたい対称の文字列を入れる
    public EnemyFieldOfView() : base("Player")
    {
        
    }

    private void Start()
    {
        circle_collider_ = GetComponent<CircleCollider2D>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(checkFieldOfView(other))
        {
            if (on_field_of_view != null)
            {
                on_field_of_view(other);
            }
        }

        //視界から消えた場合
        else
        {
            if (exit_field_of_view != null)
            {
                exit_field_of_view();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (exit_field_of_view != null)
        {
            exit_field_of_view();
        }
    }
}
