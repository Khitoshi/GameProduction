using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyFOV : MonoBehaviour
{
    [SerializeField] private float angle;//視界のアングル

    public GameObject target; //追いかける対象のTransform
    [SerializeField] private float speed;  　 　　　//敵の速度
    private Rigidbody2D rigidbody2D;                //敵のRigidbody2D
    private Vector3 enemyPosition;                  //敵のポジション

    //視界の距離
    private CircleCollider2D circle_collider;

    //onTriggerStay時に使用するtag
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
        //otherがトリガーのタグか検索して、-1の(ない)場合返す
        if (!TriggerTag.Contains(other.tag)) return;

        //視界の角度内に収まっているか
        Vector3 pos_delta = other.transform.position - this.transform.position;
        //TODOenemyのむいている方向にdirectionを変更
        Vector3 direction = transform.up;
        float target_angle = Vector3.Angle(direction, pos_delta);

        //target_angleがangleに収まっていない場合返す
        if (target_angle >= angle)
        {
            //ObjectIndication(other.GetComponent<SpriteRenderer>(), 0);
            return;
        }

        //トリガーのタグでRayCastを行う
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
                //オブジェクトの透明度変更
                //ObjectIndication(other.GetComponent<SpriteRenderer>(), 1);
                //ここに視界に入った時に使いたい処理を書く
                transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
            }
        }
    }

}
