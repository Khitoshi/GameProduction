using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverStaging : StateBase
{
    public StagingObject staging_object_;

    private float text_up_time_;     //�e�L�X�g�̊g�厞��

    private float time_ = 0.0f;

    public GameObject text_object_;

    //�R���X�g���N�^
    public GameOverStaging(StagingObject staging) { staging_object_ = staging; }
    //�X�e�[�g�ɓ��������̃��\�b�h
    public void enter()
    {
        text_up_time_ = 0.5f;

        //prefab����I�u�W�F�N�g����
        text_object_ = Instantiate(staging_object_.objects_[0]);

        //�ŏ��͏������\������
        Vector3 scale = text_object_.transform.localScale;
        scale = new Vector3(0.1f, 0.1f, 0.1f);
        text_object_.transform.localScale = scale;

        //��ʒ����ɏo��
        text_object_.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, 0);

    }
    //�X�e�[�g�Ŏ��s���郁�\�b�h
    public void execute() 
    {
        //�������g��\��
        if(time_ < text_up_time_)
        {
            Vector3 scale = text_object_.transform.localScale;
            scale += new Vector3(0.1f, 0.1f, 0.1f);
            text_object_.transform.localScale = scale;
        }

        //���o���Ԃ̏I��
        if (time_ > staging_object_.max_staging_time)
            this.exit();

        time_ += Time.deltaTime;

    }
    //�X�e�[�g����o�Ă����Ƃ��̃��\�b�h
    public void exit() 
    {
        Destroy(text_object_);
    }
}
