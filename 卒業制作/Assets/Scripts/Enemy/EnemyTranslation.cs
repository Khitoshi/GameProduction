using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyTranslation : MonoBehaviour
    {

<<<<<<< HEAD
        [SerializeField] private bool is_vertical { get; } //�c�����Ɉړ����邩
        [SerializeField] private float speed { get; } = 3.0f; //�ړ����x
        //[SerializeField] private float changeTime = 3.0f;
        [SerializeField] private float changeTime { get; } = 3;

        private float timer;
        private int direction = 1;//1�Ȃ�O�i�����A-1�Ȃ������
        //private Rigidbody2D rigidbody2D ;
        private new Rigidbody2D rigidbody2D;
=======
        [SerializeField] private bool _isVertical { get; } //�c�����Ɉړ����邩
        [SerializeField] private float _speed { get; } = 3.0f; //�ړ����x
        //[SerializeField] private float changeTime = 3.0f;
        [SerializeField] private float _changeTime { get; } = 3;
>>>>>>> 06c6f599a9f159f9d902045eea49ea9da3face6e

        private float _timer;
        private int _direction = 1;//1�Ȃ�O�i�����A-1�Ȃ������
        //private Rigidbody2D rigidbody2D ;
        private Rigidbody2D _rigidbody2D;

<<<<<<< HEAD
=======
        private GameObject _FOVLight;

>>>>>>> 06c6f599a9f159f9d902045eea49ea9da3face6e
        public Vector3 A { get; private set; }

        // Start is called before the first frame update
        void Start()
        {
<<<<<<< HEAD
            rigidbody2D = GetComponent<Rigidbody2D>();
            timer = changeTime;
            FOVLight = transform.Find("FOV_Light").gameObject;
=======
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _timer = _changeTime;
            _FOVLight = transform.Find("FOV_Light").gameObject;
>>>>>>> 06c6f599a9f159f9d902045eea49ea9da3face6e
        }

        // Update is called once per frame
        void Update()
        {
            //��莞�ԊԊu�ňړ��������t�����ɂ���
<<<<<<< HEAD
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                direction = -direction;
                timer = changeTime;
=======
            _timer -= Time.deltaTime;
            if (_timer < 0)
            {
                _direction = -_direction;
                _timer = _changeTime;
>>>>>>> 06c6f599a9f159f9d902045eea49ea9da3face6e
            }
        }

        void FixedUpdate()
        {
            Vector2 position = transform.position;
            Quaternion rotation = Quaternion.Euler(0, 0, 0);
<<<<<<< HEAD
            if (is_vertical)
            {
                //�c�����̈ړ�����
                position.y += speed * Time.deltaTime * direction;
                rotation = Quaternion.Euler(0, 0, 180 * -direction);
                A = transform.up * direction;
=======
            if (_isVertical)
            {
                //�c�����̈ړ�����
                position.y += _speed * Time.deltaTime * _direction;
                rotation = Quaternion.Euler(0, 0, 180 * -_direction);
                A = transform.up * _direction;
>>>>>>> 06c6f599a9f159f9d902045eea49ea9da3face6e
            }
            else
            {
                //�������̈ړ�
<<<<<<< HEAD
                position.x += speed * Time.deltaTime * direction;
                rotation = Quaternion.Euler(0, 0, 90 * -direction);
                A = transform.right * direction;
            }
            FOVLight.transform.rotation = rotation;

            //�����V�X�e���Ɉʒu��`����
            rigidbody2D.MovePosition(position);
=======
                position.x += _speed * Time.deltaTime * _direction;
                rotation = Quaternion.Euler(0, 0, 90 * -_direction);
                A = transform.right * _direction;
            }
            _FOVLight.transform.rotation = rotation;

            //�����V�X�e���Ɉʒu��`����
            _rigidbody2D.MovePosition(position);
>>>>>>> 06c6f599a9f159f9d902045eea49ea9da3face6e
        }
    }
}
