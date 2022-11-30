using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Experimental.Rendering.Universal;
using System.Collections.ObjectModel;

//各キャラクターオブジェクトの視野角
public class CharacterFieldOfView : MonoBehaviour
{
    //視界のアングル
    [SerializeField] private float angle_;

    //視界の距離
    private CircleCollider2D circle_collider_;

    //onTriggerStay時に使用するtag
    private readonly System.Collections.ObjectModel.ReadOnlyCollection<string> trigger_tag_;
    public CharacterFieldOfView(string raycast_mask)
    {
        //onTriggerStay時に使用するtag
        trigger_tag_ = Array.AsReadOnly<string>(new string[] {raycast_mask});
    }

    //視野角の中にいるか判定する
    public bool checkFielOfView(Collider2D other)
    {
        //otherがトリガーのタグか検索して、-1の(ない)場合返す
        if (!trigger_tag_.Contains(other.tag)) return false;

        //視界の角度内に収まっているか
        //接触オブジェクトへのベクトル
        Vector3 pos_delta = other.transform.position - this.transform.position;
        //接触オブジェクトの上方向ベクトル
        Vector3 direction = other.transform.up;

        //接触オブジェクトの上方向ベクトルから接触オブジェクト方向ベクトルまでの角度を取得する
        float target_angle = Vector3.Angle(direction, pos_delta);

        //視界の角度より大きい場合は視野角外とする
        if (target_angle >= angle_)
        {
            return false;
        }

        //自身はレイキャスト判定しない為のマスク処理
        int layer_mask = ~LayerMask.GetMask(LayerMask.LayerToName(this.gameObject.layer));

        //接触オブジェクト方向へのレイキャスト処理
        RaycastHit2D hit = Physics2D.Raycast(transform.position, pos_delta, circle_collider_.radius, layer_mask);
        if (hit.collider == other)
        {
            //視野角内に入った
            return true;
        }
        return false;

        //TODO:接触オブジェクト方向へのベクトルを算出、そのベクトルを正規化
        //自身の上方向ベクトルを取得
        //上記二つのベクトルをatanfにより、角度算出
        //算出した角度が視野角より小さければ視野角の中にいる判定で上記と同じ処理ならないか確認する

    }

}
