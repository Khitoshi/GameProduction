using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gauge : MonoBehaviour
{
    [SerializeField] 
    Image image1;
    Image image2;

    [SerializeField] private CanvasGroup canvas;
    public PlayerTrapMove trapMove;
    public bool isMaxGauge;
    
    float gaugeAmount;

    void Start()
    {
        image2 = GameObject.Find("Canvas/Image2").GetComponent<Image>();
        image1 = GameObject.Find("Canvas/Image1").GetComponent<Image>();

        image2.type = Image.Type.Filled;
        image2.fillMethod = Image.FillMethod.Horizontal;
        image2.fillOrigin = 0;
        image2.fillAmount = 0;

        image1.enabled = false;
        image2.enabled = false; 

        isMaxGauge = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(trapMove.gaugePlus)
        {
            image1.enabled = true;
            image2.enabled = true;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                KeyDownProcess();
                if (gaugeAmount >= 1f)
                {
                    image1.enabled = false;
                    image2.enabled = false;

                    MaxProcess();
                }
            }
        }
    }

    private void KeyDownProcess()
    {
        //ÉQÅ[ÉWÇ™ëùÇ¶ÇÈ
        gaugeAmount += 6.0f * Time.deltaTime;
        image2.color = new Color(1.0f, 1.0f, 0.0f);

        image2.fillAmount = gaugeAmount;
    }


    private void  MaxProcess()
    {
        gaugeAmount = 0f;

        image2.color = new Color(1.0f, 1.0f, 1.0f);
        isMaxGauge = true;
    }
}
