using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�v���C���[�p�̈ړ��Ǘ��N���X
public class PlayerMove : CharacterMove
{
    //���͂ɉ������������v�Z����
    public void inputMove()
    {
        if (Input.GetKey("left") || Input.GetKey(KeyCode.A))
        {
           
            if(Input.GetKey("up") || Input.GetKey(KeyCode.W))
            {
                add_speed_.y = move_speed_ * MOVE_DIAGONAL_SPEED;
                add_speed_.x = -move_speed_ * MOVE_DIAGONAL_SPEED;
            }

            else if (Input.GetKey("down") || Input.GetKey(KeyCode.S))
            {
                add_speed_.y = -move_speed_ * MOVE_DIAGONAL_SPEED;
                add_speed_.x = -move_speed_ * MOVE_DIAGONAL_SPEED;
            }

            //�c���̓��͖���
            else
            {
                add_speed_.x = -move_speed_;
            }
        }
        else if (Input.GetKey("right") || Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey("up") || Input.GetKey(KeyCode.W))
            {
                add_speed_.y = move_speed_ * MOVE_DIAGONAL_SPEED;
                add_speed_.x = move_speed_ * MOVE_DIAGONAL_SPEED;
            }

            else if (Input.GetKey("down") || Input.GetKey(KeyCode.S))
            {
                add_speed_.y = -move_speed_ * MOVE_DIAGONAL_SPEED;
                add_speed_.x = move_speed_ * MOVE_DIAGONAL_SPEED;
            }

            //�c���̓��͖���
            else
            {
                add_speed_.x = move_speed_;
            }
            
        }

        //�������̓��͖���
        else
        {
            add_speed_.x = 0.0f;
        }

        if (Input.GetKey("up") || Input.GetKey(KeyCode.W))
        {
            if (Input.GetKey("left") || Input.GetKey(KeyCode.A))
            {
                add_speed_.y = move_speed_ * MOVE_DIAGONAL_SPEED;
                add_speed_.x = -move_speed_ * MOVE_DIAGONAL_SPEED;
            }

            else if (Input.GetKey("right") || Input.GetKey(KeyCode.D))
            {
                add_speed_.y = move_speed_ * MOVE_DIAGONAL_SPEED;
                add_speed_.x = move_speed_ * MOVE_DIAGONAL_SPEED;
            }

            else
            {
                add_speed_.y = move_speed_;
            }

        }
        else if (Input.GetKey("down") || Input.GetKey(KeyCode.S))
        {
            if (Input.GetKey("left") || Input.GetKey(KeyCode.A))
            {
                add_speed_.y = -move_speed_ * MOVE_DIAGONAL_SPEED;
                add_speed_.x = -move_speed_ * MOVE_DIAGONAL_SPEED;
            }

            else if (Input.GetKey("right") || Input.GetKey(KeyCode.D))
            {
                add_speed_.y = -move_speed_ * MOVE_DIAGONAL_SPEED;
                add_speed_.x = move_speed_ * MOVE_DIAGONAL_SPEED;
            }

            else
            {
                add_speed_.y = -move_speed_;
            }
        }

        //�c���̓��͖���
        else
        {
            add_speed_.y = 0.0f;
        }
    }
}
