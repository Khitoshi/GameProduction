using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�v���C���[�p�̎���p�Ǘ��N���X
public class PlayerFieldOfView : CharacterFieldOfView
{
    //�R���X�g���N�^(GetComponent�ɂăN���X�𐶐�����鎞�ɂ��R���X�g���N�^�͌Ă΂��)
    //�����̕�����͎���p�����C�L���X�g�������Ώ̂̕����������
    public PlayerFieldOfView() : base("Enemy")
    {
    }
}
