using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeService : MonoBehaviour
{
    private enum StateFadeLabel
    {
        None,
        FadeIn,
        FadeOut
    }

    [SerializeField]
    private Image fadeImage;

    [SerializeField]
    private float speed = 1.0f;

    private StateFadeLabel state;



    // Update is called once per frame
    void Update()
    {
        switch(state)
        {
            case StateFadeLabel.FadeIn:
                updateFadeIn();
                break;
            case StateFadeLabel.FadeOut:
                updateFadeOut();
                break;
        }
        
    }

    public void fadeIn()
    {
        //�t�F�[�h�J�n
        state = StateFadeLabel.FadeIn;
        fadeImage.gameObject.SetActive(true);
    }

    public void fadeOut()
    {
        //�t�F�[�h�A�E�g�J�n
        state = StateFadeLabel.FadeOut;
        fadeImage.gameObject.SetActive(true);
    }

    public bool isFading()
    {
        //�t�F�[�h����
        return state != StateFadeLabel.None;
    }

    private void updateFadeIn()
    {
        //�t�F�[�h��X�V����
        Color color = fadeImage.color;
        color.a -= speed * Time.deltaTime;
        if(color.a <= 0.0f)
        {
            color.a = 0.0f;
            state = StateFadeLabel.None;
            fadeImage.gameObject.SetActive(false);
        }

        fadeImage.color = color;

    }

    private void updateFadeOut()
    {
        //�t�F�[�h�A�E�g�X�V����
        Color color = fadeImage.color;
        color.a += speed * Time.deltaTime;
        if(color.a >= 1.0f)
        {
            color.a = 1.0f;
            state = StateFadeLabel.None;
        }
        fadeImage.color = color;
    }
}
