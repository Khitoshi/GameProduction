using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTranslation : MonoBehaviour
{
    public bool vertical; //�c�����Ɉړ����邩
    public float speed = 3.0f; //�ړ����x
    public float changeTime = 3.0f;
    private float timer;
    private int direction = 1;//1�Ȃ�O�i�����A�[�P�Ȃ������
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

        if (vertical)
        {
            //�c�����̈ړ�����
            position.y = position.y + speed * Time.deltaTime * direction;
        }
        else
        {
            //�������̈ړ�
            position.x = position.x + speed * Time.deltaTime * direction;
        }

        //�����V�X�e���Ɉʒu��`����

        rigidbody2D.MovePosition(position);
    }
}
