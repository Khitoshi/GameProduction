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
        //フェード開始
        state = StateFadeLabel.FadeIn;
        fadeImage.gameObject.SetActive(true);
    }

    public void fadeOut()
    {
        //フェードアウト開始
        state = StateFadeLabel.FadeOut;
        fadeImage.gameObject.SetActive(true);
    }

    public bool isFading()
    {
        //フェード中か
        return state != StateFadeLabel.None;
    }

    private void updateFadeIn()
    {
        //フェード印更新処理
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
        //フェードアウト更新処理
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
