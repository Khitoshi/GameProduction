using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//キャラクターオブジェクトの移動制御基底クラス
public class CharacterMove : MonoBehaviour
{
    //移動速度
    public float move_speed_ = 0.0f;

    //加速度
    protected Vector2 add_speed_ = default(Vector2);

    //回転スピード
    public float rotate_speed_ = 20;

    //斜め移動時の定数(1/√2 = 0.7f)
    protected const float MOVE_DIAGONAL_SPEED = 0.7f;

    //移動更新関数
    public void move() 
    {
        //現在の座標を取得する
        Vector3 current_position = transform.position;

        //移動分の座標を取得する
        Vector3 move = new Vector3(add_speed_.x, add_speed_.y, current_position.z);

        //現在の座標に移動ベクトルを足す
        Vector3 update_pos = current_position;
        update_pos += move * Time.deltaTime;
        transform.position = update_pos;
    }

}
