using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//プレイヤー用の視野角管理クラス
public class PlayerFieldOfView : CharacterFieldOfView
{
    //コンストラクタ(GetComponentにてクラスを生成される時にもコンストラクタは呼ばれる)
    //引数の文字列は視野角がレイキャストしたい対称の文字列を入れる
    public PlayerFieldOfView() : base("Enemy")
    {
    }
}
