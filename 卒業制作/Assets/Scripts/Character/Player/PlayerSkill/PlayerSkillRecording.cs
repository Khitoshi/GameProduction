using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillRecording : MonoBehaviour
{

    //���[�h��p�̃��X�g�쐬(�X�L��No, �X�L���N���X)
    private readonly Dictionary<int, PlayerSkill> records_ = new Dictionary<int, PlayerSkill>();

    //�w�肳�ꂽ�X�L�����擾
    public PlayerSkill getSkill(int skill_no)
    {
        return records_[skill_no];
    }

    // Start is called before the first frame update
    void Start()
    {
        //�}�X�^�[�f�[�^����X�L�����X�g���쐬����
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
