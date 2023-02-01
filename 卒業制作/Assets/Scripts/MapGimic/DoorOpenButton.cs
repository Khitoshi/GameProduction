using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;

namespace MapGimics
{
    //ボタンで開くドア
    public class DoorOpenButton : MapGimic
    {
        //変化させたいタイルマップ
        [SerializeField] private Tilemap tile_;
        //変化させたいタイルのポジション
        [SerializeField] private Vector3Int gimic_posiiton_;
        //変化後のタイル画像
        [SerializeField] private TileBase tilebase_after_;

        public void Start()
        {
        }

        private void Update()
        {
        }

        public void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.tag != "Player") return;

            //タイルを変化させる
            ChangeTile(tile_, gimic_posiiton_, tilebase_after_);

            /*
            CameraEvent cameraevent;
            cameraevent = GetComponent<CameraEvent>();
            cameraevent.flag = true;
            */
            CameraEvent cameraevent = GameObject.Find("カメライベント用").GetComponent<CameraEvent>();
            Vector3 position = new Vector3(gimic_posiiton_.x, gimic_posiiton_.y, -5);
            cameraevent.SetEvent(position, true);

            //自身を削除
            Destroy(gameObject);
        }
    }
}
