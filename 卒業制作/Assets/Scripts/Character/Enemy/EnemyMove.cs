using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�G�l�~�[�p�̓����𐧌䂷��N���X
public class EnemyMove : CharacterMove
{
    //������ؑ֎��̃^�C�~���O�𑪂�^�C�}�[
    private float switch_timer_ = 0.0f;

    //�����݈̂ړ����̈ړ������ؑփ^�C��
    public float HORIZONAL_SWITCH_TIME = 0.0f;

    //�����݂̂ɓ����G
    public void horizonalMove()
    {
        if (switch_timer_ > HORIZONAL_SWITCH_TIME)
        {
            if (add_speed_.x <= 0.0f)
                add_speed_.x = move_speed_;
            else
                add_speed_.x = -move_speed_;

            switch_timer_ = 0.0f;
        }

        switch_timer_ += Time.deltaTime;
    }

    public void rotationOnlyMove()
    {
        Vector3 update_euler = new Vector3(0.0f, 0.0f, 30.0f * Time.deltaTime);
        transform.Rotate(update_euler, Space.World);
    }

    //�^�[�Q�b�g��ǐՂ���֐�
    public Vector3 moveToTarget(Vector3 mine_position, Vector3 target_position)
    {
        Vector3 update_position = mine_position;
        update_position = Vector2.MoveTowards(mine_position, target_position,move_speed_ * Time.deltaTime);

        return update_position;
    }

}
