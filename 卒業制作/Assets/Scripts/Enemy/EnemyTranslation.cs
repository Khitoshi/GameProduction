using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyTranslation : MonoBehaviour
    {

        [SerializeField] private bool is_vertical { get; } //�c�����Ɉړ����邩
        [SerializeField] private float speed { get; } = 3.0f; //�ړ����x
        //[SerializeField] private float changeTime = 3.0f;
        [SerializeField] private float changeTime { get; } = 3;

        private float timer;
        private int direction = 1;//1�Ȃ�O�i�����A-1�Ȃ������
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
            //��莞�ԊԊu�ňړ��������t�����ɂ���
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
                //�c�����̈ړ�����
                position.y += speed * Time.deltaTime * direction;
                rotation = Quaternion.Euler(0, 0, 180 * -direction);
                A = transform.up * direction;
            }
            else
            {
                //�������̈ړ�
                position.x += speed * Time.deltaTime * direction;
                rotation = Quaternion.Euler(0, 0, 90 * -direction);
                A = transform.right * direction;
            }
            FOVLight.transform.rotation = rotation;

            //�����V�X�e���Ɉʒu��`����
            rigidbody2D.MovePosition(position);
        }
    }
}
