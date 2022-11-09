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
        if (other.gameObject.tag == "Player") //視界の範囲内の当たり判定
        {
            //name = "1"
            //視界の角度内に収まっているか
            Vector3 posDelta = other.transform.position - this.transform.position;
            float target_angle = Vector3.Angle(this.transform.up, posDelta);

            if (target_angle < angle) //target_angleがangleに収まっているかどうか
            {
                Debug.DrawRay(transform.position, posDelta);

                //if (Physics.Raycast(this.transform.position, posDelta, out RaycastHit hit)) //Rayを使用してtargetに当たっているか判別
                //{
                //    Debug.DrawRay(transform.position, posDelta);
                //    if (hit.collider == other)
                //    {
                //        Debug.Log(hit.collider.name);
                //    }


                    //プレイヤーを追いかける

                    transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
                //}
            }
        }
    }

}
