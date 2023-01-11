using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;


namespace MapGimic
{
    //鍵で開くドア
    public class DoorWithKey : MapGimic
    {
        //タイルマップでのポジション
        [SerializeField] private List<Vector3Int> tilemap_positions_;
        //自身のタイルマップ
        [SerializeField] private Tilemap    this_tilemap_;
        //開錠後の扉のタイル
        [SerializeField] private TileBase   tilebase_after_;
        //アイテムのフラグが格納されているデータベース
        [SerializeField] private ItemFlagDateBase item_flag_datebase_;

        [SerializeField] private int door_opne_flag_;
        void Start()
        {
            //key_ = GetComponent<Item.Key>();
            //Debug.Log(key_.flag_bit_);

            

        }
    
        // Update is called once per frame
        void Update()
        {
            
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag != "Player") return;

            //playerのpostionをvector3Intに変換
            Vector3Int PlayerPos = new Vector3Int((int)collision.transform.position.x, (int)collision.transform.position.y, (int)collision.transform.position.z);

            //上下左右のpositionを登録
            List<Vector3Int> positions = new List<Vector3Int>();

            //鍵を拾っているかの判定
            if (item_flag_datebase_.Key != door_opne_flag_) return;
            
            

            foreach(Vector3Int pos in tilemap_positions_)
            {
                //自身のタイルを変更
                ChangeTile(this_tilemap_, pos, tilebase_after_);
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.tag != "Player") return;
            //collision.gameObject.GetComponent<PlayerInterFace>().transitionGameClearState();
        }
    }
}
