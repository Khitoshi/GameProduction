using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  //SceneManager���g�p����̂ɕK�v

//�G���h���[�����̃e�L�X�g�X�N���[���p
public class EndRollScript : MonoBehaviour
{
    //�@�e�L�X�g�̃X�N���[���X�s�[�h
    [SerializeField]
    private float text_scroll_speed = 30;
    //�@�e�L�X�g�̐����ʒu
    [SerializeField]
    private float text_limit_position = 730f;
    //�@�G���h���[�����I���������ǂ���
    private bool is_stop_endroll;
    //�@�V�[���ړ��p�R���[�`��
    private Coroutine endroll_coroutine;

    //�Ō�ɃX�y�[�X�L�[�ǉ�
    [SerializeField]
    private Text text_space_prefab_;

    //Prefab���畡���p
    private Text text_space_;

    [SerializeField]
    private Canvas canvas;

    // Update is called once per frame
    void Update()
    {
        //�@�G���h���[�����I��������
        if (is_stop_endroll)
        {
            endroll_coroutine = StartCoroutine(GoToNextScene());
        }
        else
        {
            //�@�G���h���[���p�e�L�X�g�����~�b�g���z����܂œ�����
            if (transform.position.y <= text_limit_position)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y + text_scroll_speed * Time.deltaTime);
            }
            else
            {
                is_stop_endroll = true;

                if(text_space_prefab_ != null)
                {
                    text_space_ = Instantiate<Text>(text_space_prefab_);

                    text_space_.transform.SetParent(canvas.transform, false);
                }
            }
        }
    }

    IEnumerator GoToNextScene()
    {
        //�@5�b�ԑ҂�
        yield return new WaitForSeconds(1f);

        if (Input.GetKeyDown("space"))
        {
            StopCoroutine(endroll_coroutine);
            SceneManager.LoadScene("TitleScene");
        }

        yield return null;
    }
}
