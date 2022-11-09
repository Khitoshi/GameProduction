using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTranslation : MonoBehaviour
{
    public bool vertical; //縦方向に移動するか
    public float speed = 3.0f; //移動速度
    public float changeTime = 3.0f;
    private float timer;
    private int direction = 1;//1なら前進方向、ー１なら後ろ方向
    //private Rigidbody2D rigidbody2D ;
    private new Rigidbody2D rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        timer = changeTime;
    }

    // Update is called once per frame
    void Update()
    {
        //一定時間間隔で移動方向を逆方向にする
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }
    }

    void FixedUpdate()
    {
        Vector2 position = transform.position;

        if (vertical)
        {
            //縦方向の移動処理
            position.y = position.y + speed * Time.deltaTime * direction;
        }
        else
        {
            //横方向の移動
            position.x = position.x + speed * Time.deltaTime * direction;
        }

        //物理システムに位置を伝える

        rigidbody2D.MovePosition(position);
    }
}
