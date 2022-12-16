using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//�Q�[�����o�R���g���[���N���X
public class GameStagingController : MonoBehaviour
{

    //���o�̐�
    public enum GAME_STAGING_LABEL
    {
        none = -1,
        game_over = 0,
        game_clear,
    }

    //���o�p���X�g
    public StateMachine state_machine_;

    //���o�����ǂ���
    public bool is_staging_ { set; get; } = false;

    public GAME_STAGING_LABEL staging_state_ = GAME_STAGING_LABEL.none;

    // Start is called before the first frame update
    void Start()
    {

        //�Q�[���I�[�o�[���o�X�e�[�g�o�^��
        state_machine_ = GetComponent<StateMachine>();

        //�Q�[���I�[�o�[���o�X�e�[�g�o�^��
    }

    // Update is called once per frame
    void Update()
    {
        //���o���Z�b�g���ꂽ���͏������s��
        if (staging_state_ != GAME_STAGING_LABEL.none)
        {
            state_machine_.execute();
        }
    }

    public void setStaging(GAME_STAGING_LABEL staging_label)
    {
        staging_state_ = staging_label;
        if (staging_label != GAME_STAGING_LABEL.none)
        {
            is_staging_ = true;
            state_machine_.setState((int)staging_label);
            state_machine_.setSubState((int)staging_label);

        }
        else
            is_staging_ = false;
    }

    public void setStagingNone()
    {
        staging_state_ = GAME_STAGING_LABEL.none;
        is_staging_ = false;
    }
}
