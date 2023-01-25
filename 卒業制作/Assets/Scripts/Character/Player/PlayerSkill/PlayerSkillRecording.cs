using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSkillRecording : MonoBehaviour
{

    //スキルのロード、セーブ専用キー
    public static string SKILL_HASH_KEY = "THIS_SKILL";

    //スキル情報のスロットプレハブ
    [SerializeField]
    private GameObject skill_slot_;

    //スキルデータベース(Paramaterフォルダ内のSkill Data Table)
    [SerializeField]
    private SkillDataTable skill_data_base_;

    //現在選択中のプレイヤースキル
    [SerializeField]
    private CurrentPlayerSkill current_skill_;

    //スキルアイコン表示パネルサイズ
    private Vector2 panel_size_;

    //スキルアイコンセルサイズ
    private Vector2 cell_size_;

    //スキルアイコン間の幅
    private Vector3 cell_spacing_;

    // Start is called before the first frame update
    void Start()
    {
        //自身の四角形姿勢を取得、スキルアイコン表示パネルサイズを取得
        RectTransform rect = transform.GetComponent<RectTransform>();
        panel_size_ = rect.rect.size;

        //セルのサイズ、セル間の幅を取得
        GridLayoutGroup grid_layout = transform.GetComponent<GridLayoutGroup>();
        cell_spacing_ = grid_layout.spacing;
        cell_size_ = grid_layout.cellSize;

        //用意されたスキル分、スキルアイコン情報スロットを生成する
        createSkillSlot(skill_data_base_.skill_datas_);

        //セーブデータがある場合の処理
        if (PlayerPrefs.HasKey(SKILL_HASH_KEY))
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
        int i = 0;  //ゲームオブジェクトのNo決定用
        int x_num = 0;  //列数を記録する変数
        int y_num = 0; //行数を記録する変数

        //スキルデータベース分スキルスロット作成処理
        foreach (var skill in skill_datas)
        {
            //Prefab/UI/Skill内のプレハブからスロットのインスタンス化
            var instance_slot = Instantiate<GameObject>(skill_slot_, transform);
            //　スロットゲームオブジェクトの名前を設定
            instance_slot.name = "SkillSlot" + i++;
            //　Scaleを設定しないと0になるので設定
            instance_slot.transform.localScale = new Vector3(1f, 1f, 1f);

            //現在のスキルアイコンのX座標を計算
            var offset_x = x_num * (int)(cell_size_.x + cell_spacing_.x);

            //X座標がスキルアイコン表示パネルサイズを超えたら、改行するのでX座標を0にする
            if(offset_x > panel_size_.x)
            {
                x_num = 0;
                offset_x = 0;
                y_num++;
            }

            //Paramaterフォルダ内のSkill Data Table内に設定されたスキルアイコン情報をセットする(説明文の表示用にX座標、Y座標情報を送る。Yは0固定で良い)
            instance_slot.GetComponent<ProcessingSkillSlot>().setSkillData(skill, offset_x, 0);

            x_num++;
        }

    }

    void setSkillNo(int no)
    {
        //THIS_SKILLという名前に引数のnoを格納する
        PlayerPrefs.SetInt(SKILL_HASH_KEY, no);
    }

    int getSkillNo()
    {
        //THIS_SKILLという名前に記録された整数値を取得する
        return PlayerPrefs.GetInt(SKILL_HASH_KEY);
    }

    public void skillSave()
    {
        //セーブ処理
        PlayerPrefs.Save();
    }

}

