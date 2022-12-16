using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//エネミー用の視野角管理クラス
public class EnemyFieldOfView : CharacterFieldOfView
{

    //public delegate void onFieldOfView(Collider2D other);
    public delegate void onFieldOfView();
    public onFieldOfView on_field_of_view;//徘徊(pursuit)

    public delegate void exitFieldOfView();
    public exitFieldOfView exit_field_of_view;//追跡(wander)

    public delegate void setPlayerFindingLocation(Vector3 position);
    public setPlayerFindingLocation set_player_finding_location;//追跡時のtarget position　set

    //コンストラクタ(GetComponentにてクラスを生成される時にもコンストラクタは呼ばれる)
    //引数の文字列は視野角がレイキャストしたい対称の文字列を入れる
    public EnemyFieldOfView() : base("Player")
    {
    }

    private void Start()
    {
        circle_collider_ = GetComponent<CircleCollider2D>();
    }

    private void Update()
    {   
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        //探査対象のプレイヤー以外は処理をしない
        if (other.gameObject.tag == "Player")
        {

            if (checkFieldOfView(other))
            {
                //playerを発見した時
                if (on_field_of_view != null)
                {
                    set_player_finding_location(other.transform.position);
                    on_field_of_view();
                }
            }

            //視界から消えた場合
            //else
            //{
            //    if (exit_field_of_view != null)
            //    {
            //        exit_field_of_view();
            //    }
            //}
        }


    }

    private void OnTriggerExit2D(Collider2D other)
    {

        //探査対象のプレイヤー以外は処理をしない
        if (other.gameObject.tag != "Player")
            return;

        //視界範囲から出るので索敵(Wander)にする
        //if (exit_field_of_view != null)
        //{
        //    exit_field_of_view();
        //}
    }
}
