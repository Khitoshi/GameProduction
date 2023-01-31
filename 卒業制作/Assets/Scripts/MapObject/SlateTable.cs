using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SlateTable : MonoBehaviour
{

    //フラグを格納しているデータベース
    [SerializeField]private SlateFlagDatabase slate_flag_db_;

    //どの石板が有効かを表すビット
    [SerializeField] private byte slate_bit_;
    
    //ギミック解除後のTileBaseが乗っているタイルマップ
    [SerializeField] private Tilemap tilemap;

    //ギミック解除後のTileBase
    [SerializeField] private TileBase tilebase_after_change_;

    //TileBaseの位置
    [SerializeField] private Vector3Int position;


    //ギミックの状態フラグ false = ギミック解除前
    private bool gimic_flag_;

    // Start is called before the first frame update
    void Start()
    {
        gimic_flag_ = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        //プレイヤー以外除外
        if (collision.gameObject.tag != "Player") return;
        
        //台座に合ったフラグが立っているかをチェック
        if ((slate_bit_ & slate_flag_db_.SlateFlagBit_) == 0) return;

        //ギミック解除アイテムを所持しているのでtilebaseを解除
        //Tilemap tile_map = GetComponent<Tilemap>();
        //tilemap.SetTile(position, tilebase_after_change_);

        tilemap.gameObject.SetActive(false);

        this.transform.GetChild(0).gameObject.SetActive(true);

        //ギミックを解除したのでフラグを立てる
        gimic_flag_ = true;
    }

    public bool GetGimicFlag()
    {
        return gimic_flag_;
    }

}
