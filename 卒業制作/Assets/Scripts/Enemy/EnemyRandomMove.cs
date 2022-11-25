using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyRandomMove : MonoBehaviour
    {
        [SerializeField] private GameObject _player;//�����������I�u�W�F�N�g���C���X�y�N�^�[��������
        [SerializeField] private int _speed = 5; //�I�u�W�F�N�g�������œ����X�s�[�h����

        [SerializeField] private float _randomXMax = 7;
        [SerializeField] private float _randomXMin = -4;

        [SerializeField] private float _randomYMax = 4;
        [SerializeField] private float _randomYMin = -7;

        private Vector3 _movePosition; //�I�u�W�F�N�g�̖ړI�n��ۑ�

        // Start is called before the first frame update
        void Start()
        {
            _movePosition = MoveRandomPosition();//���s���I�u�W�F�N�g�̖ړI�n��ݒ�
        }
    
        // Update is called once per frame
        void Update()
        {
            if (_movePosition == _player.transform.position)//player�I�u�W�F�N�g���ړI�n�ɒB�������
            {
                _movePosition = MoveRandomPosition();
            }
            //player�I�u�W�F�N�g���ړI�n�Ɉړ��A�ړ����x
            this._player.transform.position = Vector3.MoveTowards(_player.transform.position, _movePosition, _speed * Time.deltaTime);
        }
    
        private Vector3 MoveRandomPosition()
        {
            Vector3 randomPosi = new Vector3(Random.Range(_randomXMin, _randomXMax), Random.Range(_randomYMin, _randomYMax), 0);
            return randomPosi;
        }
    }
}