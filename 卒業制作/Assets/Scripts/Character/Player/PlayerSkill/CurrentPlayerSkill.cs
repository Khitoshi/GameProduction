using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CurrentPlayerSkill : MonoBehaviour
{

    //現在選択されているスキルアイコンをセット
    public void setCurrentSkillIcon(SkillData skill_data)
    {
        transform.GetChild(0).GetComponent<Text>().text = skill_data.skill_name_;
        transform.GetChild(1).GetComponent<Image>().sprite = skill_data.skill_image_;
    }

}
