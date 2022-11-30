using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    //�Ӗ��s���N���X...Random�Ȃ̂�Player���ړ�...?
    public class EnemyRandomMove : MonoBehaviour
    {
        [SerializeField] private GameObject player_;//�����������I�u�W�F�N�g���C���X�y�N�^�[��������
        [SerializeField] private int speed_ = 5; //�I�u�W�F�N�g�������œ����X�s�[�h����

        [SerializeField] private float randomX_max_ = 7;
        [SerializeField] private float randomX_min_ = -4;

        [SerializeField] private float randomY_max_ = 4;
        [SerializeField] private float randomY_min = -7;

        private Vector3 move_target_position; //�I�u�W�F�N�g�̖ړI�n��ۑ�

        // Start is called before the first frame update
        void Start()
        {
            move_target_position = MoveRandomPosition();//���s���I�u�W�F�N�g�̖ړI�n��ݒ�
        }
    
        // Update is called once per frame
        void Update()
        {
            if (move_target_position == player_.transform.position)//player�I�u�W�F�N�g���ړI�n�ɒB�������
            {
                move_target_position = MoveRandomPosition();
            }
            //player�I�u�W�F�N�g���ړI�n�Ɉړ��A�ړ����x
            this.player_.transform.position = Vector3.MoveTowards(player_.transform.position, move_target_position, speed_ * Time.deltaTime);
        }
    
        private Vector3 MoveRandomPosition()
        {
            Vector3 randomPosi = new Vector3(Random.Range(randomX_min_, randomX_max_), Random.Range(randomY_min, randomY_max_), 0);
            return randomPosi;
        }
    }
}