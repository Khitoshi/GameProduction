using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�v���C���[�p�̈ړ��Ǘ��N���X
public class PlayerMove : CharacterMove
{
    //�A�j���[�V�����Đ��p�ϐ�
    public bool walk_animation_ = false;

    //���͂ɉ������������v�Z����
    public void inputMove()
    {
        if (Input.GetKey("left") || Input.GetKey(KeyCode.A))
        {
           
            if(Input.GetKey("up") || Input.GetKey(KeyCode.W))
            {
                add_speed_.y = move_speed_ * MOVE_DIAGONAL_SPEED;
                add_speed_.x = -move_speed_ * MOVE_DIAGONAL_SPEED;

                //������͒l(135�� = 2.35rad)
                direction_angle_ = 2.35f;
            }

            else if (Input.GetKey("down") || Input.GetKey(KeyCode.S))
            {
                add_speed_.y = -move_speed_ * MOVE_DIAGONAL_SPEED;
                add_speed_.x = -move_speed_ * MOVE_DIAGONAL_SPEED;

                //�����͒l(225�� = 3.92rad)
                direction_angle_ = 3.92f;
            }

            //�c���̓��͖���
            else
            {
                add_speed_.x = -move_speed_;

                //�����͒l(180�� = 3.14rad)
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

                //�E����͒l(45�� = 0.78rad)
                direction_angle_ = 0.78f;
            }

            else if (Input.GetKey("down") || Input.GetKey(KeyCode.S))
            {
                add_speed_.y = -move_speed_ * MOVE_DIAGONAL_SPEED;
                add_speed_.x = move_speed_ * MOVE_DIAGONAL_SPEED;

                //�E�����͒l(315�� = 5.49rad)
                direction_angle_ = 5.49f;
            }

            //�c���̓��͖���
            else
            {
                add_speed_.x = move_speed_;
                //�E���͒l(0�� = 0rad)
                direction_angle_ = 0.0f;
            }
            walk_animation_ = true;
        }

        //�������̓��͖���
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

                //������͒l(135�� = 2.35rad)
                direction_angle_ = 2.35f;
            }

            else if (Input.GetKey("right") || Input.GetKey(KeyCode.D))
            {
                add_speed_.y = move_speed_ * MOVE_DIAGONAL_SPEED;
                add_speed_.x = move_speed_ * MOVE_DIAGONAL_SPEED;

                //�E����͒l(45�� = 0.78rad)
                direction_angle_ = 0.78f;
            }

            else
            {
                add_speed_.y = move_speed_;
                //����͒l(90�� = 1.57rad)
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

                //�����͒l(225�� = 3.92rad)
                direction_angle_ = 3.92f;
            }

            else if (Input.GetKey("right") || Input.GetKey(KeyCode.D))
            {
                add_speed_.y = -move_speed_ * MOVE_DIAGONAL_SPEED;
                add_speed_.x = move_speed_ * MOVE_DIAGONAL_SPEED;

                //�E�����͒l(315�� = 5.49rad)
                direction_angle_ = 5.49f;
            }

            else
            {
                add_speed_.y = -move_speed_;
                //�����͒l(270�� = 4.71rad)
                direction_angle_ = 4.71f;
            }
            walk_animation_ = true;
        }

        //�c���̓��͖���
        else
        {
            add_speed_.y = 0.0f;
        }
    }
}
