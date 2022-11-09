using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyFOV : MonoBehaviour
{
    [SerializeField] private float angle;//���E�̃A���O��

    public GameObject target; //�ǂ�������Ώۂ�Transform
    [SerializeField] private float speed;  �@ �@�@�@//�G�̑��x
    private Rigidbody2D rigidbody2D;                //�G��Rigidbody2D
    private Vector3 enemyPosition;                  //�G�̃|�W�V����




    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Stay: " + $"{Stay}");
        //State = 0;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        //name = "0"
        if (other.gameObject.tag == "Player") //���E�͈͓̔��̓����蔻��
        {
            //name = "1"
            //���E�̊p�x���Ɏ��܂��Ă��邩
            Vector3 posDelta = other.transform.position - this.transform.position;
            float target_angle = Vector3.Angle(this.transform.up, posDelta);

            if (target_angle < angle) //target_angle��angle�Ɏ��܂��Ă��邩�ǂ���
            {
                Debug.DrawRay(transform.position, posDelta);

                //if (Physics.Raycast(this.transform.position, posDelta, out RaycastHit hit)) //Ray���g�p����target�ɓ������Ă��邩����
                //{
                //    Debug.DrawRay(transform.position, posDelta);
                //    if (hit.collider == other)
                //    {
                //        Debug.Log(hit.collider.name);
                //    }


                    //�v���C���[��ǂ�������

                    transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
                //}
            }
        }
    }

}
