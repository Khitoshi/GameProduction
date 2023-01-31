using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//プレイヤー用の移動管理クラス
public class PlayerMove : CharacterMove
{
    //アニメーション再生用変数
    public bool walk_animation_ = false;

    //入力に応じた動きを計算する
    public void inputMove()
    {
        if (Input.GetKey("left") || Input.GetKey(KeyCode.A))
        {
           
            if(Input.GetKey("up") || Input.GetKey(KeyCode.W))
            {
                add_speed_.y = move_speed_ * MOVE_DIAGONAL_SPEED;
                add_speed_.x = -move_speed_ * MOVE_DIAGONAL_SPEED;

                //左上入力値(135° = 2.35rad)
                direction_angle_ = 2.35f;
            }

            else if (Input.GetKey("down") || Input.GetKey(KeyCode.S))
            {
                add_speed_.y = -move_speed_ * MOVE_DIAGONAL_SPEED;
                add_speed_.x = -move_speed_ * MOVE_DIAGONAL_SPEED;

                //左下力値(225° = 3.92rad)
                direction_angle_ = 3.92f;
            }

            //縦軸の入力無し
            else
            {
                add_speed_.x = -move_speed_;

                //左入力値(180° = 3.14rad)
                direction_angle_ = 3.14f;
            }

            walk_animation_ = true;
        }
        else if (Input.GetKey("right") || Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey("up") || Input.GetKey(KeyCode.W))
            {
                add_speed_.y = move_speed_ * MOVE_DIAGONAL_SPEED;
                add_speed_.x = move_speed_ * MOVE_DIAGONAL_SPEED;

                //右上入力値(45° = 0.78rad)
                direction_angle_ = 0.78f;
            }

            else if (Input.GetKey("down") || Input.GetKey(KeyCode.S))
            {
                add_speed_.y = -move_speed_ * MOVE_DIAGONAL_SPEED;
                add_speed_.x = move_speed_ * MOVE_DIAGONAL_SPEED;

                //右下入力値(315° = 5.49rad)
                direction_angle_ = 5.49f;
            }

            //縦軸の入力無し
            else
            {
                add_speed_.x = move_speed_;
                //右入力値(0° = 0rad)
                direction_angle_ = 0.0f;
            }
            walk_animation_ = true;
        }

        //横無しの入力無し
        else
        {
            add_speed_.x = 0.0f;
            walk_animation_ = false;
        }

        if (Input.GetKey("up") || Input.GetKey(KeyCode.W))
        {
            if (Input.GetKey("left") || Input.GetKey(KeyCode.A))
            {
                add_speed_.y = move_speed_ * MOVE_DIAGONAL_SPEED;
                add_speed_.x = -move_speed_ * MOVE_DIAGONAL_SPEED;

                //左上入力値(135° = 2.35rad)
                direction_angle_ = 2.35f;
            }

            else if (Input.GetKey("right") || Input.GetKey(KeyCode.D))
            {
                add_speed_.y = move_speed_ * MOVE_DIAGONAL_SPEED;
                add_speed_.x = move_speed_ * MOVE_DIAGONAL_SPEED;

                //右上入力値(45° = 0.78rad)
                direction_angle_ = 0.78f;
            }

            else
            {
                add_speed_.y = move_speed_;
                //上入力値(90° = 1.57rad)
                direction_angle_ = 1.57f;
            }
            walk_animation_ = true;
        }
        else if (Input.GetKey("down") || Input.GetKey(KeyCode.S))
        {
            if (Input.GetKey("left") || Input.GetKey(KeyCode.A))
            {
                add_speed_.y = -move_speed_ * MOVE_DIAGONAL_SPEED;
                add_speed_.x = -move_speed_ * MOVE_DIAGONAL_SPEED;

                //左下力値(225° = 3.92rad)
                direction_angle_ = 3.92f;
            }

            else if (Input.GetKey("right") || Input.GetKey(KeyCode.D))
            {
                add_speed_.y = -move_speed_ * MOVE_DIAGONAL_SPEED;
                add_speed_.x = move_speed_ * MOVE_DIAGONAL_SPEED;

                //右下入力値(315° = 5.49rad)
                direction_angle_ = 5.49f;
            }

            else
            {
                add_speed_.y = -move_speed_;
                //下入力値(270° = 4.71rad)
                direction_angle_ = 4.71f;
            }
            walk_animation_ = true;
        }

        //縦軸の入力無し
        else
        {
            add_speed_.y = 0.0f;
        }
    }
}
