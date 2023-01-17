using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillRecording : MonoBehaviour
{

    //ロード専用のリスト作成(スキルNo, スキルクラス)
    private readonly Dictionary<int, PlayerSkill> records_ = new Dictionary<int, PlayerSkill>();

    //指定されたスキルを取得
    public PlayerSkill getSkill(int skill_no)
    {
        return records_[skill_no];
    }

    // Start is called before the first frame update
    void Start()
    {
        //マスターデータからスキルリストを作成する
        foreach (SkillData skill in MasterData.skill_data_table_.skill_datas_)
        {
            records_.Add(skill.this_skill_.getMineSkillNo(), skill.this_skill_);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
