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

    //���E�̋���
    private CircleCollider2D circle_collider;

    //onTriggerStay���Ɏg�p����tag
    private readonly System.Collections.ObjectModel.ReadOnlyCollection<string> TriggerTag = Array.AsReadOnly<string>(new string[] {
            "Player"
        });

    // Start is called before the first frame update
    void Start()
    {
        circle_collider = GetComponent<CircleCollider2D>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        //other���g���K�[�̃^�O���������āA-1��(�Ȃ�)�ꍇ�Ԃ�
        if (!TriggerTag.Contains(other.tag)) return;

        //���E�̊p�x���Ɏ��܂��Ă��邩
        Vector3 pos_delta = other.transform.position - this.transform.position;
        //TODOenemy�̂ނ��Ă��������direction��ύX
        Vector3 direction = transform.up;
        float target_angle = Vector3.Angle(direction, pos_delta);

        //target_angle��angle�Ɏ��܂��Ă��Ȃ��ꍇ�Ԃ�
        if (target_angle >= angle)
        {
            //ObjectIndication(other.GetComponent<SpriteRenderer>(), 0);
            return;
        }

        //�g���K�[�̃^�O��RayCast���s��
        foreach (string tag in TriggerTag)
        {
            int layer_mask = LayerMask.GetMask(tag);
            float light_radius = circle_collider.radius;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, pos_delta, light_radius, layer_mask);
            //Debug.Log(other.name);
            if (hit.collider == other)
            {
                //Debug.Log(hit.transform.name);
                Debug.DrawRay(transform.position, pos_delta);
                //�I�u�W�F�N�g�̓����x�ύX
                //ObjectIndication(other.GetComponent<SpriteRenderer>(), 1);
                //�����Ɏ��E�ɓ��������Ɏg����������������
                transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
            }
        }
    }

}
