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
        image1 = GetComponent<Image>();
        image2 = GetComponent<Image>();


        image2.type = Image.Type.Filled;
        image2.fillMethod = Image.FillMethod.Horizontal;
        image2.fillOrigin = 0;
        image2.fillAmount = 0;

        canvas.alpha = 0.0f;

        isMaxGauge = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(trapMove.gaugePlus)
        {
            canvas.alpha = 1.0f; 

            if (Input.GetKeyDown(KeyCode.Space))
            {
                //ƒQ[ƒW‚ª‘‚¦‚é
                gaugeAmount += 4.0f * Time.deltaTime;
                image1.color = new Color(1.0f, 1.0f, 0.0f);

                image2.fillAmount = gaugeAmount;
                if (gaugeAmount >= 1f)
                {
                    gaugeAmount = 0f;
                    Debug.Log("Max");

                    image1.color = new Color(1.0f, 1.0f, 1.0f);
                    canvas.alpha = 0.0f;
                    isMaxGauge = true;
                }
            }
        }
    }
}
