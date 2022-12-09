using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//���o���̃I�u�W�F�N�g
public struct StagingObject
{
    public List<GameObject> objects_;  //���o���ɕK�v�ƂȂ�I�u�W�F�N�g��ǉ����Ă���(Prefab�̃I�u�W�F�N�g�̂ݒǉ�)
    public bool can_operation_;  //���o���A�v���C���[������\���ǂ���

    public bool can_object_update_; //�S�ẴI�u�W�F�N�g�����o���ɍX�V�\���ǂ���

    public float max_staging_time;  //���o����

};

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
    private List<StagingObject> staging_objects_;

    private StagingObject[] game_staging_;
    public GameObject game_over_text_;

    public StateMachine state_machine_;
    public StagingState staging_;
    public GameOverStaging game_over_staging_;

    //���o�����ǂ���
    private bool is_staging_ { set; get; } = false;

    private GAME_STAGING_LABEL staging_state_ = GAME_STAGING_LABEL.none;

    // Start is called before the first frame update
    void Start()
    {
        staging_objects_ = new List<StagingObject>();

        //�Q�[���I�[�o�[���̐ݒ聫
        game_staging_ = new StagingObject[1];
        if (game_over_text_ != null)
        {
            game_staging_[0].objects_ = new List<GameObject>();
            game_staging_[0].objects_.Add(game_over_text_);
        }
        game_staging_[0].can_operation_ = false;
        game_staging_[0].can_object_update_ = false;
        game_staging_[0].max_staging_time = 3.0f;
        //�Q�[���I�[�o�[���̐ݒ聪

        for (int i = 0; i < game_staging_.Length; i++)
        {
            staging_objects_.Add(game_staging_[i]);
        }

        //�Q�[���I�[�o�[���o�X�e�[�g�o�^��
        state_machine_ = GetComponent<StateMachine>();

        staging_ = GetComponent<StagingState>();
        state_machine_.registerState(staging_);
        //game_over_staging_ = new GameOverStaging(game_staging_[0]);
        game_over_staging_ = GetComponent<GameOverStaging>();
        state_machine_.registerSubState((int)GAME_STAGING_LABEL.game_over, game_over_staging_);
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
            state_machine_.setState((int)GAME_STAGING_LABEL.game_over);

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
