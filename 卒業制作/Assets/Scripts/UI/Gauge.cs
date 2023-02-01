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
    public bool isMaxGauge;

    public PlayerTrapMove player_trap_move_;

    //プレイヤーが落とし穴にヒットしたか判定
    public bool is_player_hit_ = false;

    float gaugeAmount;

    void Start()
    {
        //image2 = GameObject.Find("PitFall/Image2").GetComponent<Image>();
        //image1 = GameObject.Find("PitFall/Image1").GetComponent<Image>();

        image2 = transform.parent.GetChild(2).GetComponent<Image>();
        image1 = transform.parent.GetChild(1).GetComponent<Image>();

        image2.type = Image.Type.Filled;
        image2.fillMethod = Image.FillMethod.Horizontal;
        image2.fillOrigin = 0;
        image2.fillAmount = 0;

        image1.enabled = false;
        image2.enabled = false;

        isMaxGauge = false;

        is_player_hit_ = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (is_player_hit_)
        {
            //ゲージUI表示
            image1.enabled = true;
            image2.enabled = true;

            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) ||
                 Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                KeyDownProcess();
                if (gaugeAmount >= 1f)
                {
                    //ゲージUI非表示
                    image1.enabled = false;
                    image2.enabled = false;

                    is_player_hit_ = false;
                    isMaxGauge = false;

                    //プレイヤーがトラップから抜けた
                    if (player_trap_move_ != null)
                    {
                        player_trap_move_.is_trap_ = false;

                        //落とし穴に入る前へ座標を変更
                        player_trap_move_.PlayerPos();
                    }

                    MaxProcess();
                }
            }
        }
    }

    private void KeyDownProcess()
    {
        //ゲージが増える
        gaugeAmount += 6.0f * Time.deltaTime;
        image2.color = new Color(1.0f, 1.0f, 0.0f);

        image2.fillAmount = gaugeAmount;
    }


    private void MaxProcess()
    {
        gaugeAmount = 0f;

        image2.color = new Color(1.0f, 1.0f, 1.0f);
        isMaxGauge = true;
    }
}
