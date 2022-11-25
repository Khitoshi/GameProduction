using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyTranslation : MonoBehaviour
    {

        [SerializeField] private bool _isVertical { get; } //�c�����Ɉړ����邩
        [SerializeField] private float _speed { get; } = 3.0f; //�ړ����x
        //[SerializeField] private float changeTime = 3.0f;
        [SerializeField] private float _changeTime { get; } = 3;

        private float _timer;
        private int _direction = 1;//1�Ȃ�O�i�����A-1�Ȃ������
        //private Rigidbody2D rigidbody2D ;
        private Rigidbody2D _rigidbody2D;

        private GameObject _FOVLight;

        public Vector3 A { get; private set; }

        // Start is called before the first frame update
        void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _timer = _changeTime;
            _FOVLight = transform.Find("FOV_Light").gameObject;
        }

        // Update is called once per frame
        void Update()
        {
            //��莞�ԊԊu�ňړ��������t�����ɂ���
            _timer -= Time.deltaTime;
            if (_timer < 0)
            {
                _direction = -_direction;
                _timer = _changeTime;
            }
        }

        void FixedUpdate()
        {
            Vector2 position = transform.position;
            Quaternion rotation = Quaternion.Euler(0, 0, 0);
            if (_isVertical)
            {
                //�c�����̈ړ�����
                position.y += _speed * Time.deltaTime * _direction;
                rotation = Quaternion.Euler(0, 0, 180 * -_direction);
                A = transform.up * _direction;
            }
            else
            {
                //�������̈ړ�
                position.x += _speed * Time.deltaTime * _direction;
                rotation = Quaternion.Euler(0, 0, 90 * -_direction);
                A = transform.right * _direction;
            }
            _FOVLight.transform.rotation = rotation;

            //�����V�X�e���Ɉʒu��`����
            _rigidbody2D.MovePosition(position);
        }
    }
}
