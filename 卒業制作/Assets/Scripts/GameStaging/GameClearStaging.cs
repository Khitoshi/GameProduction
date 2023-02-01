using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClearStaging : StateBase
{
    public float text_up_time_ = 0.5f;     //�e�L�X�g�̊g�厞��

    private float time_ = 0.0f;

    public float max_staging_time_ = 3.0f; //���o�̏I������

    public GameObject text_object_;

    public GameObject canvas_;  //�L�����o�X

    //�R���X�g���N�^
    public GameClearStaging() { }
    //�X�e�[�g�ɓ��������̃��\�b�h
    public override void enter()
    {

        //prefab����I�u�W�F�N�g����
        text_object_ = Instantiate(text_object_);
        canvas_ = Instantiate(canvas_);
        text_object_.transform.SetParent(canvas_.transform, false);

        //�ŏ��͏������\������
        Vector3 scale = text_object_.transform.localScale;
        scale = new Vector3(0.1f, 0.1f, 0.1f);
        text_object_.transform.localScale = scale;
        time_ = 0.0f;


    }
    //�X�e�[�g�Ŏ��s���郁�\�b�h
    public override void execute()
    {
        //�������g��\��
        if (time_ < text_up_time_)
        {
            Vector3 scale = text_object_.transform.localScale;
            scale += new Vector3(0.005f, 0.005f, 0.005f);
            if (scale.x <= 1.0f)
                text_object_.transform.localScale = scale;
        }

        //���o���Ԃ̏I��
        if (time_ > max_staging_time_)
            GameManager.game_staging_controller_.state_machine_.getState().exit();

        time_ += Time.deltaTime;

    }
    //�X�e�[�g����o�Ă����Ƃ��̃��\�b�h
    public override void exit()
    {
        Destroy(text_object_);
        Destroy(canvas_);
    }
}


