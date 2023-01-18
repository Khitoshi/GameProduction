using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillRecording : MonoBehaviour
{

    //ロード専用のリスト作成(スキルNo, スキルクラス)
    private readonly List<int> records_ = new List<int>();

    //スキル情報のスロットプレハブ
    [SerializeField]
    private GameObject skill_slot_;

    //スキルデータベース
    [SerializeField]
    private SkillDataTable skill_data_base_;

    //指定されたスキルを取得
    //public int getSkillNo(int skill_no)
    //{
    //    return records_;
    //}

    // Start is called before the first frame update
    void Start()
    {
        //マスターデータからスキルリストを作成する
        //foreach (SkillData skill in MasterData.skill_data_table_.skill_datas_)
        //{
        //    records_.Add((int)skill.this_skill_);
        //}

        createSkillSlot(skill_data_base_.skill_datas_);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void createSkillSlot(SkillData[] skill_datas)
    {
        int i = 0;

        //スキルデータベース分スキルスロット作成処理
        foreach (var skill in skill_datas)
        {
            //　スロットのインスタンス化
            var instance_slot = Instantiate<GameObject>(skill_slot_, transform);
            //　スロットゲームオブジェクトの名前を設定
            instance_slot.name = "SkillSlot" + i++;
            //　Scaleを設定しないと0になるので設定
            instance_slot.transform.localScale = new Vector3(1f, 1f, 1f);
        }

    }
}

public class SkillRecord
{
    //現在設定されているスキル
    public PlayerSkill.PLAYER_SKILL_LABEL this_skill_;
    public int this_skill_no_ = (int)PlayerSkill.PLAYER_SKILL_LABEL.none;

    void setSkillNo(int no)
    {
        //THIS_SKILLという名前に引数のnoを格納する
        PlayerPrefs.SetInt("THIS_SKILL", no);
        this_skill_no_ = no;
    }

    int getSkillNo()
    {
        //THIS_SKILLという名前に記録された整数値を取得する
        return PlayerPrefs.GetInt("THIS_SKILL");
    }

    void skillSave()
    {
        //セーブ処理
        PlayerPrefs.Save();
    }

}
