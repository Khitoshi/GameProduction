using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyTranslation : MonoBehaviour
    {

        [SerializeField] private bool is_vertical { get; } //縦方向に移動するか
        [SerializeField] private float speed { get; } = 3.0f; //移動速度
        //[SerializeField] private float changeTime = 3.0f;
        [SerializeField] private float changeTime { get; } = 3;

        private float timer;
        private int direction = 1;//1なら前進方向、-1なら後ろ方向
        //private Rigidbody2D rigidbody2D ;
        private new Rigidbody2D rigidbody2D;

        private GameObject FOVLight;

        public Vector3 A { get; private set; }

        // Start is called before the first frame update
        void Start()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
            timer = changeTime;
            FOVLight = transform.Find("FOV_Light").gameObject;
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
            Quaternion rotation = Quaternion.Euler(0, 0, 0);
            if (is_vertical)
            {
                //縦方向の移動処理
                position.y += speed * Time.deltaTime * direction;
                rotation = Quaternion.Euler(0, 0, 180 * -direction);
                A = transform.up * direction;
            }
            else
            {
                //横方向の移動
                position.x += speed * Time.deltaTime * direction;
                rotation = Quaternion.Euler(0, 0, 90 * -direction);
                A = transform.right * direction;
            }
            FOVLight.transform.rotation = rotation;

            //物理システムに位置を伝える
            rigidbody2D.MovePosition(position);
        }
    }
}
