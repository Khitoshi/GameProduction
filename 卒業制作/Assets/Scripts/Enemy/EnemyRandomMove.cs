using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyRandomMove : MonoBehaviour
    {
        [SerializeField] private GameObject _player;//動かしたいオブジェクトをインスペクターから入れる
        [SerializeField] private int _speed = 5; //オブジェクトが自動で動くスピード調整

        [SerializeField] private float _randomXMax = 7;
        [SerializeField] private float _randomXMin = -4;

        [SerializeField] private float _randomYMax = 4;
        [SerializeField] private float _randomYMin = -7;

        private Vector3 _movePosition; //オブジェクトの目的地を保存

        // Start is called before the first frame update
        void Start()
        {
            _movePosition = MoveRandomPosition();//実行時オブジェクトの目的地を設定
        }
    
        // Update is called once per frame
        void Update()
        {
            if (_movePosition == _player.transform.position)//playerオブジェクトが目的地に達成すると
            {
                _movePosition = MoveRandomPosition();
            }
            //playerオブジェクトが目的地に移動、移動速度
            this._player.transform.position = Vector3.MoveTowards(_player.transform.position, _movePosition, _speed * Time.deltaTime);
        }
    
        private Vector3 MoveRandomPosition()
        {
            Vector3 randomPosi = new Vector3(Random.Range(_randomXMin, _randomXMax), Random.Range(_randomYMin, _randomYMax), 0);
            return randomPosi;
        }
    }
}