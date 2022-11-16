using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyRandomMove : MonoBehaviour
    {
        [SerializeField] private GameObject player;//動かしたいオブジェクトをインスペクターから入れる
        [SerializeField] private int speed = 5; //オブジェクトが自動で動くスピード調整

        [SerializeField] private float randomX_max = 7;
        [SerializeField] private float randomX_min = -4;

        [SerializeField] private float randomY_max = 4;
        [SerializeField] private float randomY_min = -7;

        private Vector3 movePosition; //オブジェクトの目的地を保存

        // Start is called before the first frame update
        void Start()
        {
            movePosition = moveRandomPosition();//実行時オブジェクトの目的地を設定
            
        }
    
        // Update is called once per frame
        void Update()
        {
            if (movePosition == player.transform.position)//playerオブジェクトが目的地に達成すると
            {
                movePosition = moveRandomPosition();
            }

            //playerオブジェクトが目的地に移動、移動速度
            this.player.transform.position = Vector3.MoveTowards(player.transform.position, movePosition, speed * Time.deltaTime);
        }
    
        private Vector3 moveRandomPosition()
        {
            Vector3 randomPosi = new Vector3(Random.Range(randomX_min, randomX_max), Random.Range(randomY_min, randomY_max), 0);
            return randomPosi;
        }
    }
}