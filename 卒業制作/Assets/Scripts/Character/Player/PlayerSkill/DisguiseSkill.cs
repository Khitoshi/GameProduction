using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//変装スキル、敵の発見判定から逃れる
public class DisguiseSkill : PlayerSkill
{
    private float disguise_timer_ = 0.0f;       //スキル発動中時間カウント用
    private const float DISGUISE_TIME = 5.0f;   //スキル発動時間
    private bool is_disguise_ = false;  //変装中フラッグ
    public bool is_disguise { get { return is_disguise_; } set { is_disguise_ = value; } }
    // Start is called before the first frame update
    void Start()
    {

    }

    public override bool enterSkill()
    {
        //スキルチャージ時間が終わっていなければ発動しない
        if (skill_timer_ < SKILL_CHRGE_TIME)
            return false;

        is_active_ = true;

        skill_timer_ = 0.0f;

        is_disguise = true;

        //親オブジェクトの取得処理(プレイヤーオブジェクト)
        var parent_object = transform.root.gameObject;

        parent_object.GetComponent<Animator>().SetBool("DisguiesTrigger", is_disguise);

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

        //親オブジェクトの取得処理(プレイヤーオブジェクト)
        var parent_object = transform.root.gameObject;
        parent_object.layer = LayerMask.NameToLayer("Player");

        is_disguise = false;

        parent_object.GetComponent<Animator>().SetBool("DisguiesTrigger", is_disguise);

        disguise_timer_ = 0.0f;
    }
}
