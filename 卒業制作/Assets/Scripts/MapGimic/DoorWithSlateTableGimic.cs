using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace MapGimic
{
    public class DoorWithSlateTableGimic : MapGimic
    {
        //gimic object: slate table
        [SerializeField] List<SlateTable> slate_tables_;

        //変更するTIleBaseのposition
        [SerializeField] Vector3Int position_;

        //アニメーションの再生を判断するflag false = 再生していない
        private bool is_animation_;

        private bool is_gimic_;

        TileAnimation animation_;

        // Start is called before the first frame update
        void Start()
        {
            //アニメーション再生フラグ
            is_animation_ = false;

            //ギミック解除フラグ
            is_gimic_ = false;

            //tile_animation = GetComponent<TileAnimation>();
            animation_ = GetComponent<TileAnimation>();
        }
    
        // Update is called once per frame
        void Update()
        {
            //ギミックのフラグを確認してドアを開ける
            Open();

            //tile. 
            PlayAnimation();
        }

        /// <summary>
        /// ギミックのフラグを確認して、フラグが立っている場合ドアを開ける
        /// </summary>
        private void Open()
        {
            //ギミックを解除している場合入らない
            if (is_gimic_) return;

            //flag check loop
            foreach (SlateTable slatetable in slate_tables_)
            {
                //ギミックのフラグチェック false = ギミック解除前
                if (!slatetable.GetGimicFlag()) return;
            }

            //必要なギミックが全部、解けているので
            //TileBaseを変更する

            //当たり判定を消す
            GetComponent<TilemapCollider2D>().enabled = false;

            //ギミックを解除したのでアニメーションを流すフラグを立てる
            is_animation_ = true;
            is_gimic_ = true;
        }

        /// <summary>
        /// アニメーションフラグを確認して、立っている場合アニメーションを流す
        /// </summary>
        private void PlayAnimation()
        {
            //アニメーションフラグが立っていない場合、除外する
            if (!is_animation_) return;
            //アニメーション再生
            animation_.PlayAnimation(GetComponent<Tilemap>(), position_);

            //アニメーション再生完了したのでanimationフラグをfalseにする
            is_animation_ = false;
        }
    }
}
