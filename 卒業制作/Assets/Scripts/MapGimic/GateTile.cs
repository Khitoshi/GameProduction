using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MapGimics;
using UnityEngine.Tilemaps;
using Item;

//特定の処理がくるまで壁となるタイル
public class GateTile : MapGimic
{

    private int slate_index_;

    //タイルが変化したか判定用
    private bool is_change_ = false;

    //変化後のタイル画像
    [SerializeField] private TileBase tilebase_after_;

    //ステージの石板登録用
    [SerializeField]
    private List<Slate> slate_lisit_;

    //ステージ上の石板のビット合計値用
    private int slate_bits_;

    // Start is called before the first frame update
    void Start()
    {
        slate_index_ = GameManager.date_base_manager_.flag_date_base.IndexOf(new SlateFlagDatabase());
        is_change_ = false;

        //各石板のビット合計値算出
        foreach(Slate slate in slate_lisit_)
        {
            slate_bits_ += slate.slate_flag_bit;
        }
    }

    // Update is called once per frame
    void Update()
    {
        SlateFlagDatabase slate_data_base = (SlateFlagDatabase)GameManager.date_base_manager_.flag_date_base[1];

        if (slate_data_base != null)
        {
            if(slate_data_base.SlateFlagBit_ == slate_bits_ && !is_change_)
            {
                int x = (int)transform.position.x;
                int y = (int)transform.position.y;
                int z = (int)transform.position.z;
                Vector3Int vec_int = new Vector3Int(x, y, z);
                ChangeTile(GetComponent<Tilemap>(), vec_int, tilebase_after_);
                is_change_ = true;

                //当たり判定を消す
                GetComponent<TilemapCollider2D>().enabled = false;
            }
        }
    }
}
