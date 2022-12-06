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
        Vector3 update_euler = new Vector3(0.0f, 0.0f, rotate_speed_ * Time.deltaTime);
        transform.Rotate(update_euler, Space.World);
    }

    //�^�[�Q�b�g��ǐՂ���֐�
    public Vector3 moveToTarget(Transform mine_transform, Transform target_transform)
    {

        Vector3 direction = mine_transform.position - target_transform.position;

        //���g�̉�]�l����O�����x�N�g�������߂�
        float angle_radian = mine_transform.localEulerAngles.z;
        angle_radian *= 0.01745f; //rad = dgree * (��/180)
        float add_right_angle = 1.5705f; //90�x�����l�𑫂��Ă����Ȃ��ƑO�����ɂȂ�Ȃ�

        angle_radian += add_right_angle;

        float front_x = Mathf.Cos(angle_radian);
        float front_y = Mathf.Sin(angle_radian);

        //���ςɂ��A�^�[�Q�b�g�Ƃǂꂭ�炢�p�x�������邩�v�Z����
        float dot = front_x * direction.normalized.x + front_y * direction.normalized.y;

        //�␳�l(���ϒl-1.0�`1.0���p�x���F0.0�`2.0�F�p�x��ɕ␳���܂�)
        float rot = 1.0f - dot;

        //���ϒl��-1.0�`1.0�ŕ\������Ă���A2�̒P�ʃx�N�g���̊p�x��
        //�������ق�1.0�ɋ߂Â��Ƃ��������𗘗p���ĉ�]���x�𒲐�����
        if (rot > rotate_speed_)
        {
            rot = rotate_speed_;
        }

        //���E������s�����߂�2�̒P�ʃx�N�g���̊O�ς��v�Z����
        float cross = front_x * direction.normalized.y - front_y * direction.normalized.x;  //�O�ς̌���

        //2D�̊O�ϒl�����̏ꍇ�����̏ꍇ�ɂ���č��E���肪�s����
        //���E������s�����Ƃɂ���č��E��]��I������
        if (cross < 0.0f)
        {
            Vector3 rotate = new Vector3(0.0f, 0.0f, rot * Time.deltaTime);
            mine_transform.Rotate(rotate);
        }
        else
        {
            Vector3 rotate = new Vector3(0.0f, 0.0f, -rot * Time.deltaTime);
            mine_transform.Rotate(rotate);
        }

        Vector3 update_position = mine_transform.position;
        update_position = Vector3.MoveTowards(mine_transform.position, target_transform.position, move_speed_ * Time.deltaTime);

        return update_position;
    }

}
