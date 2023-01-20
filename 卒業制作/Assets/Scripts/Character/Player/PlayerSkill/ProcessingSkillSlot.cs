using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//スキルアイコン画像などの情報を受け取り設定、表示に関する制御するクラス
public class ProcessingSkillSlot : MonoBehaviour
{
    //自身のスキルデータ格納用
    public SkillData my_skill_data_;

    //自身にマウスが接触しているかの判定用
    private bool on_mouse_point_ = false;
    public bool getOnMouse() { return on_mouse_point_; }

    //　アイテムのデータをセット
    public void setSkillData(SkillData skill_data)
    {
        my_skill_data_ = skill_data;
        //アイコンのスプライトを設定(iconの子オブジェクトの順番順に設定していく)
        transform.GetChild(0).GetComponent<Image>().sprite = my_skill_data_.skill_image_;
        transform.GetChild(1).GetComponent<Text>().text = my_skill_data_.skill_name_;
        transform.GetChild(1).GetComponent<Text>().enabled = false;     //自身が選択されていない時は文字を表示しない為にテキストコンポーネントを非アクティブにしておく
        transform.GetChild(2).GetComponent<Text>().text = my_skill_data_.skill_information_;
        transform.GetChild(2).GetComponent<Text>().enabled = false;     ////自身が選択されていない時は文字を表示しない為にテキストコンポーネントを非アクティブにしておく
    }

    //カーソルが自身へ向けられている時等の制御もこのクラスで行う

    //自身のアイコンの上にマウスがある(Event TriggerコンポーネントのPointer Enterに設定する)
    public void onMousePoint()
    {
        //自身が選択されている状態なので文字の表示を行う
        transform.GetChild(1).GetComponent<Text>().enabled = true;
        transform.GetChild(2).GetComponent<Text>().enabled = true;
        on_mouse_point_ = true;
    }

    //自身のアイコンの上からマウスが離れた(Event TriggerコンポーネントのPointer Exitに設定する)
    public void exitMousePoint()
    {
        //自身が選択されていない状態になったので文字を非表示にする
        transform.GetChild(1).GetComponent<Text>().enabled = false;
        transform.GetChild(2).GetComponent<Text>().enabled = false;
        on_mouse_point_ = false;
    }
}
