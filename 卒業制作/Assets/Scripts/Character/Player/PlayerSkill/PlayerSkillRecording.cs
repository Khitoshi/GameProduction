using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillRecording : MonoBehaviour
{

    //���[�h��p�̃��X�g�쐬(�X�L��No, �X�L���N���X)
    private readonly List<int> records_ = new List<int>();

    //�X�L�����̃X���b�g�v���n�u
    [SerializeField]
    private GameObject skill_slot_;

    //�X�L���f�[�^�x�[�X(Paramater�t�H���_����Skill Data Table)
    [SerializeField]
    private SkillDataTable skill_data_base_;

    //���ݑI�𒆂̃v���C���[�X�L��
    [SerializeField]
    private CurrentPlayerSkill current_skill_;

    // Start is called before the first frame update
    void Start()
    {

        //�p�ӂ��ꂽ�X�L�����A�X�L���A�C�R�����X���b�g�𐶐�����
        createSkillSlot(skill_data_base_.skill_datas_);

        //�Z�[�u�f�[�^������ꍇ�̏���
        if (PlayerPrefs.HasKey("THIS_SKILL"))
        {
            current_skill_.setCurrentSkillIcon(skill_data_base_.skill_datas_[getSkillNo()]);
        }

        //�Z�[�u�f�[�^���Ȃ��ꍇ�̏���
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

        //���g�̃I�u�W�F�N�g�Ɏq�I�u�W�F�N�g�����݂���Ώ������s��(�Q�[�����ɑ��݂���X�L���̐�)
        if (child_count > 0)
        {
            int child_no = 0;
            for (; child_no < child_count; child_no++)
            {
                var skill_object = transform.GetChild(child_no).GetComponent<ProcessingSkillSlot>();

                //�}�E�X���X�L���A�C�R���ƐڐG���Ă���ꍇ
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

        //�X�L���f�[�^�x�[�X���X�L���X���b�g�쐬����
        foreach (var skill in skill_datas)
        {
            //Prefab/UI/Skill���̃v���n�u����X���b�g�̃C���X�^���X��
            var instance_slot = Instantiate<GameObject>(skill_slot_, transform);
            //�@�X���b�g�Q�[���I�u�W�F�N�g�̖��O��ݒ�
            instance_slot.name = "SkillSlot" + i++;
            //�@Scale��ݒ肵�Ȃ���0�ɂȂ�̂Őݒ�
            instance_slot.transform.localScale = new Vector3(1f, 1f, 1f);

            //Paramater�t�H���_����Skill Data Table���ɐݒ肳�ꂽ�X�L���A�C�R�������Z�b�g����
            instance_slot.GetComponent<ProcessingSkillSlot>().setSkillData(skill);
        }

    }

    void setSkillNo(int no)
    {
        //THIS_SKILL�Ƃ������O�Ɉ�����no���i�[����
        PlayerPrefs.SetInt("THIS_SKILL", no);
    }

    int getSkillNo()
    {
        //THIS_SKILL�Ƃ������O�ɋL�^���ꂽ�����l���擾����
        return PlayerPrefs.GetInt("THIS_SKILL");
    }

    public void skillSave()
    {
        //�Z�[�u����
        PlayerPrefs.Save();
    }

}

