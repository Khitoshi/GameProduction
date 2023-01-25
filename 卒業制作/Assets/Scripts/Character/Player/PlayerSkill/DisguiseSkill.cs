using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//変装スキル、敵の発見判定から逃れる
public class DisguiseSkill : PlayerSkill
{
    private float disguise_timer_ = 0.0f;       //スキル発動中時間カウント用
    private const float DISGUISE_TIME = 5.0f;   //スキル発動時間
    public Sprite disguise_sprite_ = null;
    private Sprite save_sprite_ = null;
    // Start is called before the first frame update
    void Start()
    {
        //プレイヤーの画像を保存処理
        var player_sprite = GetComponentInParent<SpriteRenderer>().sprite;
        if (player_sprite != null)
        {
            save_sprite_ = player_sprite;
        }

    }

    public override bool enterSkill()
    {
        //スキルチャージ時間が終わっていなければ発動しない
        if (skill_timer_ < SKILL_CHRGE_TIME)
            return false;

        is_active_ = true;

        skill_timer_ = 0.0f;

        //変装用画像をセット
        if(disguise_sprite_ != null)
        {
            GetComponentInParent<SpriteRenderer>().sprite = disguise_sprite_;
        }

        //親オブジェクトの取得処理(プレイヤーオブジェクト)
        var parent_object = transform.root.gameObject;

        //引数の名前のレイヤー番号を取得する
        parent_object.layer = LayerMask.NameToLayer("DisguisePlayer");

        return true;
    }

    public override void moveSkill()
    {
        if (!is_active_)
        {
            return;
        }

        //発動時間終了判定
        if (disguise_timer_ > DISGUISE_TIME)
        {
            is_active_ = false;
            endSkill();
            return;
        }

        disguise_timer_ += Time.deltaTime;
    }

    public override void endSkill()
    {
        //変装時にセットした画像を元に戻す
        if (save_sprite_ != null)
        {
            GetComponentInParent<SpriteRenderer>().sprite = save_sprite_;
        }

        //親オブジェクトの取得処理(プレイヤーオブジェクト)
        var parent_object = transform.root.gameObject;
        parent_object.layer = LayerMask.NameToLayer("Player");

        disguise_timer_ = 0.0f;
    }
}
