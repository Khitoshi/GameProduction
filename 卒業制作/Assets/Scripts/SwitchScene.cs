using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  //SceneManager���g�p����̂ɕK�v

public class SwitchScene : MonoBehaviour
{
    [SerializeField]
    private Button touch_button_;

    [SerializeField]
    private string change_scene_ = null;

    // Start is called before the first frame update
    void Start()
    {
        //�^�b�`�{�^�����N���b�N���ꂽ���ɌĂ΂��֐���o�^
        touch_button_.onClick.AddListener(OnClickTouchButton);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnClickTouchButton()
    {
        if (!GameManager.fade_service_.isFading())
        {
            //�z�[����ʂւ̑J�ڊJ�n()
            //�R���[�`���ɂĎ���
            //�u�����P�v���u��莞�ԑ҂v���u�����Q�v���u��莞�ԑ҂v���u�����R�v
            //�R���[�`���́AIEnumerator��Ԃ��֐�
            //StartCoroutine�ɂČĂяo��
            StartCoroutine(DoTransitionScene());
        }

    }

    private IEnumerator DoTransitionScene()
    {

        if (change_scene_ == null)
        {
            Debug.Log("�V�[�����ݒ肳��Ă��܂���");
        }

        //�t�F�[�h�J�n
        GameManager.fade_service_.fadeOut();


        //�R���[�`���F���b��ɉ����������s�������Ƃ���񓯊��̂悤�ȏ������쐬����
        //�t�F�[�h����(isFading��false�ɂȂ�܂�)�܂ő҂�
        yield return new WaitUntil(() => !GameManager.fade_service_.isFading());
        
        //��ʂ��^������ԂŃV�[����J�ڂ���
        SceneManager.LoadScene(change_scene_);
        //�t�F�[�h�C���J�n
        GameManager.fade_service_.fadeIn();
    }
}
