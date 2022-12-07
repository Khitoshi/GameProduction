using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�L�����N�^�[�I�u�W�F�N�g�̈ړ�������N���X
public class CharacterMove : MonoBehaviour
{
    //�ړ����x
    public float move_speed_ = 0.0f;

    //�����x
    protected Vector2 add_speed_ = default(Vector2);

    //��]�X�s�[�h
    public float rotate_speed_ = 20;

    //�΂߈ړ����̒萔(1/��2 = 0.7f)
    protected const float MOVE_DIAGONAL_SPEED = 0.7f;

    //�ړ��X�V�֐�
    public void move() 
    {
        //���݂̍��W���擾����
        Vector3 current_position = transform.position;

        //�ړ����̍��W���擾����
        Vector3 move = new Vector3(add_speed_.x, add_speed_.y, current_position.z);

        //���݂̍��W�Ɉړ��x�N�g���𑫂�
        Vector3 update_pos = current_position;
        update_pos += move * Time.deltaTime;
        transform.position = update_pos;
    }

}
