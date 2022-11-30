using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Enemy
{
    //�G�l�~�[�̎��E�̔��菈���N���X
    public class EnemyFOV : MonoBehaviour
    {
        [SerializeField] private float angle_;//���E�̃A���O��

        //���E�̋���
        private CircleCollider2D circle_collider_;

        [SerializeField] public float move_speed_ { get; private set; } = 3;

        //onTriggerStay���Ɏg�p����tag
        private readonly System.Collections.ObjectModel.ReadOnlyCollection<string> trigger_tag_ = Array.AsReadOnly<string>(new string[] {
                "Player"
        });

        // Start is called before the first frame update
        void Start()
        {
            circle_collider_ = GetComponent<CircleCollider2D>();
            //rigidbody2D = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            //other���g���K�[�̃^�O���������āA-1��(�Ȃ�)�ꍇ�Ԃ�
            if (!trigger_tag_.Contains(other.tag)) return;

            //���E�̊p�x���Ɏ��܂��Ă��邩
            Vector3 pos_delta = other.transform.position - this.transform.position;
            //TODO:enemy�̂ނ��Ă��������direction��ύX
            //Vector3 direction = GetComponent<Enemy>().enemyTranslation.A;
            Vector3 direction = other.transform.up;
            float target_angle = Vector3.Angle(direction, pos_delta);
            if (target_angle >= angle_)
            {
                //ObjectIndication(other.GetComponent<SpriteRenderer>(), 0);
                return;
            }

            int layer_mask = ~LayerMask.GetMask(LayerMask.LayerToName(this.gameObject.layer));
            float light_radius = circle_collider_.radius;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, pos_delta, light_radius, layer_mask);
            if (hit.collider == other)
            {   
                //�����Ɏ��E�ɓ��������Ɏg����������������
                Debug.DrawRay(transform.position, pos_delta);

                transform.position = Vector2.MoveTowards(
                    transform.position, 
                    hit.transform.position, 
                    move_speed_ * Time.deltaTime
                    );
            }
        }
    }
}
