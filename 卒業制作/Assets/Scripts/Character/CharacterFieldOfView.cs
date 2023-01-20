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
    [SerializeField] float search_radian_start = 0.785f;    //0.785fはdgreeで45度
    [SerializeField] float search_radian_end = 2.356f;  //2.356fはdgreeで135度

    //視界の距離
    protected CircleCollider2D circle_collider_;

    //onTriggerStay時に使用するtag
    private readonly System.Collections.ObjectModel.ReadOnlyCollection<string> trigger_tag_;
    public CharacterFieldOfView(string raycast_mask)
    {
        //onTriggerStay時に使用するtag
        trigger_tag_ = Array.AsReadOnly<string>(new string[] { raycast_mask });
    }

    public void Update()
    {
        //視界のレイ方向デバッグ表示用の処理↓
        float ray_length = 1.0f;

        float offset_angle_radian = transform.parent.localEulerAngles.z;
        offset_angle_radian *= 0.01745f; //rad = dgree * (π/180)

        Vector3 ray_end1 = new Vector3(transform.parent.position.x + Mathf.Cos(search_radian_start + offset_angle_radian) * ray_length, transform.parent.position.y + Mathf.Sin(search_radian_start + offset_angle_radian), transform.position.z);
        Vector3 ray_end2 = new Vector3(transform.parent.position.x + Mathf.Cos(search_radian_end + offset_angle_radian) * ray_length, transform.parent.position.y + Mathf.Sin(search_radian_end + offset_angle_radian), transform.position.z);

        float front_x = Mathf.Cos(offset_angle_radian + 1.5705f);
        float front_y = Mathf.Sin(offset_angle_radian + 1.5705f);
        Vector3 eye_end = new Vector3(transform.parent.position.x + front_x * 2.0f, transform.parent.position.y + front_y * 2.0f, transform.parent.position.z);

        //視界のレイ方向デバッグ表示用の処理
        Color line_color = new Color(1.0f, 1.0f, 1.0f);
        Debug.DrawLine(transform.parent.position, eye_end, line_color);
        Debug.DrawLine(transform.parent.position, ray_end1, line_color);
        Debug.DrawLine(transform.parent.position, ray_end2, line_color);

        //親オブジェクトの座標を更新
        transform.position = transform.parent.position;
    }

    //視野角の中にいるか判定する
    public bool checkFieldOfView(Collider2D other)
    {
        //視界の角度内に収まっているか
        //接触オブジェクトへのベクトル
        Vector3 pos_delta = other.transform.position - transform.parent.position;

        //接触オブジェクトまでのベクトルの角度を取得する
        float target_angle = Mathf.Atan2(pos_delta.y, pos_delta.x);

        //自身の回転角度をオフセット値として持たせる
        float offset_angle_radian = transform.parent.localEulerAngles.z;
        offset_angle_radian *= 0.01745f; //rad = dgree * (π/180)

        //Atan2は0 ~ 180°, 0 ~ -180°しか算出しないので360°分のラジアンを足して補正を行う
        if (target_angle < 0.0f)
        {
            target_angle += Mathf.PI * 2;
        }

        //視野角が360度を超える場合は補正を行う
        float radian_start = search_radian_start + offset_angle_radian;
        float radian_end = search_radian_end + offset_angle_radian;
        if (radian_start > Mathf.PI * 2)
        {
            radian_start = radian_start - Mathf.PI * 2;
        }

        if (radian_end > Mathf.PI * 2)
        {
            radian_end = radian_end - Mathf.PI * 2;
        }

        //自身が回転している場合startの角度(350度)、endの角度(80度)となる場合があるので対策として下記の判定を行う
        if (radian_start < radian_end)
        {
            if (target_angle >= radian_start
                && target_angle <= radian_end)
            {
                return checkTargetRayCast(other);
            }
        }
        else
        {

            //自身の回転角によってstartの方が大きくなる場合はこれで角度判定を行う
            if (target_angle >= radian_start)
            {
                //視野角を算出する
                float diffrence_angle = search_radian_end - search_radian_start;

                //視野角を足した角度以内なら視野角の中にいる
                if (target_angle < radian_start + diffrence_angle)
                    return checkTargetRayCast(other);
            }

            //角度が360°を超えて0°からになる場合の判定
            else
            {
                //視野角のend側も0°を超えた数値になっているからそれより下か判定する
                if (target_angle <= radian_end)
                    return checkTargetRayCast(other);
            }
        }

        //Debug.Log("角度" + target_angle / 0.01745f);
        //Debug.Log("S角度" + radian_start / 0.01745f);
        //Debug.Log("E角度" + radian_end / 0.01745f);
        return false;
    }

    //ターゲットの間に他のオブジェクトが無いか判定する関数
    public bool checkTargetRayCast(Collider2D other)
    {
        Vector2 mine_position = new Vector2(transform.parent.position.x, transform.parent.position.y);
        Vector2 target_position = new Vector2(other.transform.position.x, other.transform.position.y);

        //レイを飛ばす方向を算出
        Vector2 direction = target_position - mine_position;

        //自身はレイキャスト対象ならないようにマスクする
        int layer_mask = ~LayerMask.GetMask(LayerMask.LayerToName(this.gameObject.layer));

        RaycastHit2D hit = Physics2D.Raycast(mine_position, direction, circle_collider_.radius, layer_mask);
        //RaycastHit2D hit = Physics2D.Raycast(mine_position, direction, circle_collider_.radius);
        if (hit)
        {
            //デバッグ用　レイキャスト可視
            //レイキャスト対象がヒットコリジョンと同じならtrue(ヒットコリジョン対象はコンストラクタ時に限定されている)
            if (hit.collider.gameObject.tag == other.gameObject.tag)
            {
                Debug.DrawRay(this.transform.position, direction);
                return true;
            }
        }

        return false;
    }
}
