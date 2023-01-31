using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�v���C���[�̔g���X�L���ƓG�̐ڐG����p
public class PlayerWaveCollision : MonoBehaviour
{
    //delegate ��t�����֐��̓��\�b�h(�������ɁZ�Z���铙)�����o����B�R�[���o�b�N�̎d�g�݂�����
    public delegate void onHitWaveEnemyCollision(Collider2D other);    //wave�I�u�W�F�N�g���G�ƐڐG�����ꍇ
    public delegate void onHitWaveOtherCollision(Collider2D other);    //wave�I�u�W�F�N�g���G�ȊO�ƐڐG�����ꍇ

    //�֐��o�^�p�ϐ���錾
    public onHitWaveEnemyCollision on_hit_wave_enemy_function_;
    public onHitWaveOtherCollision on_hit_wave_other_function_;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag != "Enemy")
        {

            //�v���C���[�ȊO�̃I�u�W�F�N�g�ƐڐG�����玩�g��j������
            if (collision.transform.tag != "Player" && collision.transform.tag != "EnemySight")
            {
                if (on_hit_wave_other_function_ != null)
                {
                    on_hit_wave_other_function_(collision);
                }

            }
            return;
        }

        if (on_hit_wave_enemy_function_ != null)
        {
            var enemy = collision.GetComponent<EnemyInterFace>();
            if (!enemy.is_hit)
            {
                enemy.subtractHp(1);
                enemy.is_hit = true;
                on_hit_wave_enemy_function_(collision);
            }
        }

    }
}
