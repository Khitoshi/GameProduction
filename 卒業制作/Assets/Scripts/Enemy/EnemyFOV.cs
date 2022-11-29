using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Enemy
{
    //エネミーの視界の判定処理クラス
    public class EnemyFOV : MonoBehaviour
    {
        [SerializeField] private float _angle;//視界のアングル

        //視界の距離
        private CircleCollider2D _circleCollider;

        [SerializeField] public float _moveSpeed { get; private set; } = 3;

        //onTriggerStay時に使用するtag
        private readonly System.Collections.ObjectModel.ReadOnlyCollection<string> _triggerTag = Array.AsReadOnly<string>(new string[] {
                "Player"
        });

        // Start is called before the first frame update
        void Start()
        {
            _circleCollider = GetComponent<CircleCollider2D>();
            //rigidbody2D = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            //otherがトリガーのタグか検索して、-1の(ない)場合返す
            if (!_triggerTag.Contains(other.tag)) return;

            //視界の角度内に収まっているか
            Vector3 pos_delta = other.transform.position - this.transform.position;
            //TODO:enemyのむいている方向にdirectionを変更
            Vector3 direction = GetComponent<Enemy>().enemyTranslation.A;
            float target_angle = Vector3.Angle(direction, pos_delta);
            if (target_angle >= _angle)
            {
                //ObjectIndication(other.GetComponent<SpriteRenderer>(), 0);
                return;
            }

            int layer_mask = ~LayerMask.GetMask(LayerMask.LayerToName(this.gameObject.layer));
            float light_radius = _circleCollider.radius;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, pos_delta, light_radius, layer_mask);
            if (hit.collider == other)
            {   
                //ここに視界に入った時に使いたい処理を書く
                Debug.DrawRay(transform.position, pos_delta);

                transform.position = Vector2.MoveTowards(
                    transform.position, 
                    hit.transform.position, 
                    _moveSpeed * Time.deltaTime
                    );
            }
        }
    }
}
