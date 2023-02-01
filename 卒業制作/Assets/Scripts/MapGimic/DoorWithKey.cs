using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;


namespace MapGimics
{
    //鍵で開くドア
    public class DoorWithKey : MapGimic
    {
        //タイルマップでのポジション
        //[SerializeField] private List<Vector3Int> tilemap_positions_;

        //自身のタイルマップ
        [SerializeField] private Tilemap this_tilemap_;
        //開錠前のタイル
        [SerializeField] private TileBase tilebase_befor_;
        //開錠後の扉のタイル
        [SerializeField] private TileBase   tilebase_after_;
        //アイテムのフラグが格納されているデータベース
        [SerializeField] private KeyFlagDateBase item_flag_datebase_;

        [SerializeField] private int door_opne_flag_;
        void Start()
        {
            this_tilemap_ = GetComponent<Tilemap>();
        }
    
        // Update is called once per frame
        void Update()
        {
            
        }

        /// <summary>
        /// ドアに触れた際の処理
        /// </summary>
        /// <param name="collision">player or enemy</param>
        private void OnCollisionStay2D(Collision2D collision)
        {
            //tag チェック
            if (collision.gameObject.tag != "Player") return;

            //鍵を拾っているかの判定
            if (item_flag_datebase_.Key != door_opne_flag_) return;

            //自身の位置をtilemapで使用できるintに変換
            Vector3Int player_position_convert_vector3int = new Vector3Int(0,0,0);
            //小数点以下切り捨てして変換
            player_position_convert_vector3int.x = (int)Mathf.Floor(collision.transform.position.x);
            player_position_convert_vector3int.y = (int)Mathf.Floor(collision.transform.position.y);
            player_position_convert_vector3int.z = (int)Mathf.Floor(collision.transform.position.z);
            Debug.Log(player_position_convert_vector3int);

            //自身の上下左右の位置を設定
            Vector3Int up,down,left,right;
            //**DirectXでは上が-だがunityでは上は+**
            up = down = left = right = player_position_convert_vector3int;
            up.y += 1;
            down.y -= 1;
            left.x += 1;
            right.x -= 1;
            
            //上記の位置を配列に纏める
            Vector3Int[] positions = new Vector3Int[] { up, down, left, right };

            //上下左右に開けられるドアがないかを調べるloop
            foreach(Vector3Int pos in positions)
            {
                //タイルの存在 チェック
                if (!this_tilemap_.HasTile(pos)) continue;

                //ドア チェック
                if(this_tilemap_.GetTile(pos).name == tilebase_befor_.name)
                {
                    Debug.Log("change");
                    //ドアがあった場合タイルを変更する
                    this_tilemap_.SetTile(pos, tilebase_after_);
                    
                    //当たり判定を消す
                    this_tilemap_.SetColliderType(pos, Tile.ColliderType.None);
                }
            }
        }

    }
}
