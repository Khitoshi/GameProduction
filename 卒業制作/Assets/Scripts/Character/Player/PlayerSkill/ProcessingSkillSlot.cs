using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//スキルアイコン画像などの情報を受け取り設定、表示に関する制御するクラス
public class ProcessingSkillSlot : MonoBehaviour
{
    //自身のスキルデータ格納用
    public SkillData my_skill_data_;

    //　アイテムのデータをセット
    public void setSkillData(SkillData skill_data)
    {
        my_skill_data_ = skill_data;
        //アイコンのスプライトを設定
        transform.GetChild(0).GetComponent<Image>().sprite = my_skill_data_.skill_image_;
    }

    //カーソルが自身へ向けられている時等の制御もこのクラスで行う
}
