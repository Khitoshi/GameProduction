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

    //スキルデータベース(Paramaterフォルダ内のSkill Data Table)
    [SerializeField]
    private SkillDataTable skill_data_base_;

    //現在選択中のプレイヤースキル
    [SerializeField]
    private CurrentPlayerSkill current_skill_;

    // Start is called before the first frame update
    void Start()
    {

        //用意されたスキル分、スキルアイコン情報スロットを生成する
        createSkillSlot(skill_data_base_.skill_datas_);

        //セーブデータがある場合の処理
        if (PlayerPrefs.HasKey("THIS_SKILL"))
        {
            current_skill_.setCurrentSkillIcon(skill_data_base_.skill_datas_[getSkillNo()]);
        }

        //セーブデータがない場合の処理
        else
        {
            setSkillNo((int)PlayerSkill.PLAYER_SKILL_LABEL.none);
            current_skill_.setCurrentSkillIcon(skill_data_base_.skill_datas_[getSkillNo()]);
            skillSave();

        }
    }

    // Update is called once per frame
    void Update()
    {
        int child_count = this.transform.childCount;

        //自身のオブジェクトに子オブジェクトが存在すれば処理を行う(ゲーム内に存在するスキルの数)
        if (child_count > 0)
        {
            int child_no = 0;
            for (; child_no < child_count; child_no++)
            {
                var skill_object = transform.GetChild(child_no).GetComponent<ProcessingSkillSlot>();

                //マウスがスキルアイコンと接触している場合
                if (skill_object.getOnMouse())
                {
                    if(Input.GetMouseButtonDown(0))
                    {
                        current_skill_.setCurrentSkillIcon(skill_object.my_skill_data_);
                        setSkillNo((int)skill_object.my_skill_data_.this_skill_);
                    }
                }
            }
        }
    }

    public void createSkillSlot(SkillData[] skill_datas)
    {
        int i = 0;

        //スキルデータベース分スキルスロット作成処理
        foreach (var skill in skill_datas)
        {
            //Prefab/UI/Skill内のプレハブからスロットのインスタンス化
            var instance_slot = Instantiate<GameObject>(skill_slot_, transform);
            //　スロットゲームオブジェクトの名前を設定
            instance_slot.name = "SkillSlot" + i++;
            //　Scaleを設定しないと0になるので設定
            instance_slot.transform.localScale = new Vector3(1f, 1f, 1f);

            //Paramaterフォルダ内のSkill Data Table内に設定されたスキルアイコン情報をセットする
            instance_slot.GetComponent<ProcessingSkillSlot>().setSkillData(skill);
        }

    }

    void setSkillNo(int no)
    {
        //THIS_SKILLという名前に引数のnoを格納する
        PlayerPrefs.SetInt("THIS_SKILL", no);
    }

    int getSkillNo()
    {
        //THIS_SKILLという名前に記録された整数値を取得する
        return PlayerPrefs.GetInt("THIS_SKILL");
    }

    public void skillSave()
    {
        //セーブ処理
        PlayerPrefs.Save();
    }

}

