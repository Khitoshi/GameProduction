using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileAnimation : MonoBehaviour
{

    //アニメーション素材
    [SerializeField] private List<TileBase> anim_tile_bases_;


    //アニメーションのループ処理を行うか? false = アニメーションを1回のみ
    //[SerializeField] private bool is_loop_ = false;
    private bool is_loop_ = false;

    //アニメーション推移タイム 1.0f = 1秒
    [SerializeField] private float wait_timer_ = 0.0f;

    //アニメーションを再生させるか? true = 再生させる
    private bool is_play_animation_ = true;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }


    /// <summary>
    /// アニメーション再生
    /// </summary>
    /// <param name="tilemap">変更したいタイルのあるタイルマップ</param>
    /// <param name="pos">タイルのポジション</param>
    public void PlayAnimation(Tilemap tilemap, Vector3Int pos)
    {
        if (!is_play_animation_) return;

        StartCoroutine(ChangeTile(tilemap, pos));

        is_play_animation_ = is_loop_;
    }

    /// <summary>
    /// タイルを変化させる
    /// </summary>
    /// <param name="tilemap">変化させたいタイルのあるタイルマップ</param>
    /// <param name="pos">タイルのポジション</param>
    /// <returns></returns>
    public IEnumerator ChangeTile(Tilemap tilemap,Vector3Int pos)
    {
        foreach(TileBase tilea in anim_tile_bases_ )
        {
            tilemap.SetTile(pos, tilea);
            //WaitForSeconds(0.3f);
            yield return new WaitForSeconds(wait_timer_);
        }
    }
}
