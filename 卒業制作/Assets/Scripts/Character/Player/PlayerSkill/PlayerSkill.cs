using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//プレイヤースキルを制御する基底クラス
public class PlayerSkill : MonoBehaviour
{
    //プレイヤーが設定出来るスキルの種類
    private enum PLAYER_SKILL_LABEL
    {
        none = 0,   //スキル無し
        dash,       //ダッシュスキル
        invincible, //無敵
        wave,       //波動
    }

    public PlayerInterFace player_inter_face_;

    private PLAYER_SKILL_LABEL skill_deiffrence_ { get; }
    public int getMineSkillNo() { return (int)skill_deiffrence_; }

    //スキルが溜まる時間
    public float SKILL_CHRGE_TIME = 3.0f;

    //スキルチャージのカウント用タイマー
    public float skill_timer_ = 0.0f;

    //スキル発動中
    public bool is_active_ = false;

    public PlayerSkill()
    {
        player_inter_face_ = GetComponent<PlayerInterFace>();
    }


    //スキル発動処理
    public virtual void enterSkill() { }
    //スキル発動中処理
    public virtual void moveSkill() { }

    //スキル発動後処理
    public virtual void endSkill() { }
}
