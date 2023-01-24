using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace MapGimic
{
    public class DoorWithSlateTableGimic : MapGimic
    {
        //gimic object: slate table
        [SerializeField] List<SlateTable> slate_table_;

        //ギミック解除後に変更するTileBase
        [SerializeField] TileBase tilebase_after_change_;

        //変更するTIleBaseのposition
        [SerializeField] Vector3Int position_;

        //アニメーションの再生を判断するflag false = 再生していない
        private bool is_animation_;

        // Start is called before the first frame update
        void Start()
        {
            is_animation_ = false;
        }
    
        // Update is called once per frame
        void Update()
        {
            //ギミックのフラグを確認してドアを開ける
            Open();



        }

        /// <summary>
        /// ギミックのフラグを確認して、フラグが立っている場合ドアを開ける
        /// </summary>
        private void Open()
        {
            //ギミック解除後にアニメーションを流すので再生中の場合は以下を処理しない
            if (is_animation_) return;

            //flag check loop
            foreach (SlateTable slatetable in slate_table_)
            {
                //ギミックのフラグチェック false = ギミック解除前
                if (!slatetable.GetGimicFlag()) return;
            }

            //必要なギミックが全部、解けているので
            //TileBaseを変更する
            Tilemap tile_map_ = GetComponent<Tilemap>();
            tile_map_.SetTile(position_, tilebase_after_change_);

            //当たり判定を消す
            //tile_map_.SetColliderType(position_, Tile.ColliderType.None);
            GetComponent<TilemapCollider2D>().enabled = false;
            GetComponent<TilemapCollider2D>().enabled = true;

            //ギミックを解除したのでアニメーションを流すフラグを立てる
            is_animation_ = true;
        }

        /// <summary>
        /// アニメーションフラグを確認して、立っている場合アニメーションを流す
        /// </summary>
        private void PlayAnimation()
        {
            //アニメーションフラグが立っていない場合、除外する
            if (!is_animation_) return;




        }


    }
}
