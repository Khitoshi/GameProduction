using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextUi : MonoBehaviour
{
    public Text text_button_screen_;    //画面にランダムで表示するボタン用
    public Text text_ui_;       //画面にボタンを押せと表示する用
    public TypeKey type_key;

    //プレイヤーがいるか判定する
    public bool is_player_ = false;

    public float speed = 1.0f;

    private int count = 0;
    private float time;

    
    void Start()
    {
        text_button_screen_.enabled = false;
        text_ui_.enabled = false;
    }

    void Update()
    {
        if (is_player_)
        {
            text_button_screen_.enabled = true;
            text_ui_.enabled = true;

            text_ui_.text = "画面に表示された文字を押せ";


            if (type_key.text_finish)
            {
                finish();

            }
            else
            {
                Indication();
            }
        }
    }

    public void Indication()
    {
        count = type_key.key_num;

        if(type_key.max_judge())
        {
            switch (count)
            {
                case 1:
                    text_button_screen_.text = " W ";
                    break;

                case 2:
                    text_button_screen_.text = " A ";
                    break;

                case 3:
                    text_button_screen_.text = " S ";
                    break;

                case 4:
                    text_button_screen_.text = " D ";
                    break;
            }
        }

       
    }

    private void finish()
    {
        text_ui_.enabled = false;
        text_button_screen_.text = "成功！";
       

        Invoke("TextEnable", 1.0f);
    }

    private void TextEnable()
    {
        text_button_screen_.enabled = false;
       
    }

    Color GetAlphaColor(Color color)
    {
        time += Time.deltaTime * 2.0f * speed;
        color.a = Mathf.Sin(time); 
        return color;
    }
}
