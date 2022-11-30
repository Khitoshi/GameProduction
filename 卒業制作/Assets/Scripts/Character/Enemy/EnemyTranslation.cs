using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyTranslation : MonoBehaviour
    {
        [SerializeField] private bool is_vertical_ { get; } //縦方向に移動するか
        [SerializeField] private float speed_ { get; } = 3.0f; //移動速度
        //[SerializeField] private float changeTime = 3.0f;
        [SerializeField] private float change_time_ { get; } = 3;

        private float timer_;
        private int direction_ = 1;//1なら前進方向、-1なら後ろ方向
        //private Rigidbody2D rigidbody2D ;
        private new Rigidbody2D rigidbody2D_;

        private GameObject fov_light_;

        //public Vector3 A { get; private set; }

        // Start is called before the first frame update
        void Start()
        {
            rigidbody2D_ = GetComponent<Rigidbody2D>();
            timer_ = change_time_;
            fov_light_ = transform.Find("FOV_Light").gameObject;
        }

        // Update is called once per frame
        void Update()
        {
            //一定時間間隔で移動方向を逆方向にする
            timer_ -= Time.deltaTime;
            if (timer_ < 0)
            {
                direction_ = -direction_;
                timer_ = change_time_;
            }
        }

        void FixedUpdate()
        {
            Vector2 position = transform.position;
            Quaternion rotation = Quaternion.Euler(0, 0, 0);
            if (is_vertical_)
            {
                //縦方向の移動処理
                position.y += speed_ * Time.deltaTime * direction_;
                rotation = Quaternion.Euler(0, 0, 180 * -direction_);
                //A = transform.up * direction_;
            }
            else
            {
                //横方向の移動
                position.x += speed_ * Time.deltaTime * direction_;
                rotation = Quaternion.Euler(0, 0, 90 * -direction_);
                //A = transform.right * direction_;
            }
            fov_light_.transform.rotation = rotation;

            //物理システムに位置を伝える
            rigidbody2D_.MovePosition(position);
        }
    }
}
