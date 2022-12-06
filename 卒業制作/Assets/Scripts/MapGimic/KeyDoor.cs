using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;


namespace MapGimic
{
    //鍵で開くドア
    public class KeyDoor : MapGimic
    {
        //タイルマップでのポジション
        [SerializeField] private Vector3Int this_tilemap_position_;
        //自身のタイルマップ
        [SerializeField] private Tilemap    this_tilemap_;
        //開錠後の扉のタイル
        [SerializeField] private TileBase   tilebase_after_;
        //アイテムのフラグが格納されているデータベース
        [SerializeField] private ItemFlagDateBase item_flag_datebase_;

        // Start is called before the first frame update
        void Start()
        {
        }
    
        // Update is called once per frame
        void Update()
        {
            
        }
    
        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.tag != "Player") return;
            
            //鍵を拾っているかの判定
            if(item_flag_datebase_.Key == 1)
            {
                //自身のタイルを変更
                ChangeTile(this_tilemap_, this_tilemap_position_, tilebase_after_);
            }
        }
    }
}
