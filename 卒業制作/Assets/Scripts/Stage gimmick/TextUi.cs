using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextUi : MonoBehaviour
{
    public Text text_ui;
    public Text text_ui_1;
    public TypeKey type_key;
    public PlayerTrapMove trap_move;

    public float speed = 1.0f;

    private int count = 0;
    private float time;

    
    void Start()
    {
        text_ui.enabled = false;
        text_ui_1.enabled = false;
    }

    void Update()
    {
        if (trap_move.is_fall_)
        {
            text_ui.enabled = true;
            text_ui_1.enabled = true;

            text_ui_1.text = "âÊñ Ç…ï\é¶Ç≥ÇÍÇΩï∂éöÇâüÇπ";


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
                    text_ui.text = " W ";
                    break;

                case 2:
                    text_ui.text = " A ";
                    break;

                case 3:
                    text_ui.text = " S ";
                    break;

                case 4:
                    text_ui.text = " D ";
                    break;
            }
        }

       
    }

    private void finish()
    {
        text_ui_1.enabled = false;
        text_ui.text = "ê¨å˜ÅI";
       

        Invoke("TextEnable", 1.0f);
    }

    private void TextEnable()
    {
        text_ui.enabled = false;
       
    }

    Color GetAlphaColor(Color color)
    {
        time += Time.deltaTime * 2.0f * speed;
        color.a = Mathf.Sin(time); 
        return color;
    }
}
