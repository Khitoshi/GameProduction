using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�v���C���[���g�����΂��X�L��
public class WaveSkill : PlayerSkill
{

    //�g���̃v���n�u
    [SerializeField]
    private GameObject wave_object_prefab_;

    //�v���n�u���烍�[�h�����f�[�^�𒼐ڍ폜�o���Ȃ��̂ŕ����p�Ƀf�[�^��p�ӂ���
    private GameObject wave_object_;

    private float wave_timer_ = 0.0f;       //�X�L�����������ԃJ�E���g�p
    private const float WAVE_TIME = 2.0f;   //�X�L����������
    public float wave_speed_ = 3.0f;    //�g���̐i�s���x
    private float wave_direction_ = 0.0f;   //�g���̐i�s����
    public float wave_power = 5.0f;     //�g���̃m�b�N�o�b�N�p���[

    public void Start()
    {
        //�X�L���̃`���[�W���Ԃ�ݒ�
        SKILL_CHRGE_TIME = 1.5f;

    }

    public override bool enterSkill()
    {
        //�X�L���`���[�W���Ԃ��I����Ă��Ȃ���Δ������Ȃ�
        if (skill_timer_ < SKILL_CHRGE_TIME)
            return false;

        //wave�I�u�W�F�N�g�쐬�A�v���C���[�̎p�����𑗂�
        wave_object_ = Instantiate<GameObject>(wave_object_prefab_) as GameObject;

        wave_direction_ = player_inter_face_.player_move_.direction_angle_;
        wave_object_.transform.position = player_inter_face_.transform.position;

        is_active_ = true;

        skill_timer_ = 0.0f;

        return true;
    }

    public override void moveSkill()
    {
        if (!is_active_)
        {
            return;
        }

        //�������ԏI������
        if (wave_timer_ > WAVE_TIME)
        {
            is_active_ = false;
            endSkill();

            //�X�L���������ԏI���Ȃ̂Ŏ��g���폜
            if (wave_object_ != null)
                Destroy(wave_object_);
            return;
        }

        waveMove();
        wave_timer_ += Time.deltaTime;
    }

    public override void endSkill()
    {

        wave_timer_ = 0.0f;
    }

    //�g���̓���
    private void waveMove()
    {
        Vector3 direction = new Vector3(Mathf.Cos(wave_direction_), Mathf.Sin(wave_direction_), 0.0f);

        float wave_speed_frame_ = wave_speed_ * Time.deltaTime;

        Vector3 wave_update = new Vector3(direction.x * wave_speed_frame_, direction.y * wave_speed_frame_, 0.0f);

        //���W�X�V
        wave_object_.transform.position = wave_object_.transform.position + wave_update;
    }

    //�G�̓����蔻��
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag != "Enemy")
        {
            //�v���C���[�ȊO�̃I�u�W�F�N�g�ƐڐG�����玩�g��j������
            if (collision.transform.tag != "Player")
            {
                if (wave_object_ != null)
                    Destroy(wave_object_);
            }
            return;
        }

        collision.rigidbody.AddForce(new Vector2(Mathf.Cos(wave_direction_) * wave_power, Mathf.Sin(wave_direction_) * wave_power));

        Debug.Log("�g���ڐG");
    }
}
