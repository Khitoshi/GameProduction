using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyRandomMove : MonoBehaviour
    {
        [SerializeField] private GameObject player;//�����������I�u�W�F�N�g���C���X�y�N�^�[��������
        [SerializeField] private int speed = 5; //�I�u�W�F�N�g�������œ����X�s�[�h����

        [SerializeField] private float randomX_max = 7;
        [SerializeField] private float randomX_min = -4;

        [SerializeField] private float randomY_max = 4;
        [SerializeField] private float randomY_min = -7;

        private Vector3 movePosition; //�I�u�W�F�N�g�̖ړI�n��ۑ�

        // Start is called before the first frame update
        void Start()
        {
            movePosition = moveRandomPosition();//���s���I�u�W�F�N�g�̖ړI�n��ݒ�
            
        }
    
        // Update is called once per frame
        void Update()
        {
            if (movePosition == player.transform.position)//player�I�u�W�F�N�g���ړI�n�ɒB�������
            {
                movePosition = moveRandomPosition();
            }

            //player�I�u�W�F�N�g���ړI�n�Ɉړ��A�ړ����x
            this.player.transform.position = Vector3.MoveTowards(player.transform.position, movePosition, speed * Time.deltaTime);
        }
    
        private Vector3 moveRandomPosition()
        {
            Vector3 randomPosi = new Vector3(Random.Range(randomX_min, randomX_max), Random.Range(randomY_min, randomY_max), 0);
            return randomPosi;
        }
    }
}