using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    //意味不明クラス...RandomなのにPlayerを移動...?
    public class EnemyRandomMove : MonoBehaviour
    {
        [SerializeField] private GameObject player_;//動かしたいオブジェクトをインスペクターから入れる
        [SerializeField] private int speed_ = 5; //オブジェクトが自動で動くスピード調整

        [SerializeField] private float randomX_max_ = 7;
        [SerializeField] private float randomX_min_ = -4;

        [SerializeField] private float randomY_max_ = 4;
        [SerializeField] private float randomY_min = -7;

        private Vector3 move_target_position; //オブジェクトの目的地を保存

        // Start is called before the first frame update
        void Start()
        {
            move_target_position = MoveRandomPosition();//実行時オブジェクトの目的地を設定
        }
    
        // Update is called once per frame
        void Update()
        {
            if (move_target_position == player_.transform.position)//playerオブジェクトが目的地に達成すると
            {
                move_target_position = MoveRandomPosition();
            }
            //playerオブジェクトが目的地に移動、移動速度
            this.player_.transform.position = Vector3.MoveTowards(player_.transform.position, move_target_position, speed_ * Time.deltaTime);
        }
    
        private Vector3 MoveRandomPosition()
        {
            Vector3 randomPosi = new Vector3(Random.Range(randomX_min_, randomX_max_), Random.Range(randomY_min, randomY_max_), 0);
            return randomPosi;
        }
    }
}