using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MapGimic
{
    public class PlayerStealthGimic : MapGimic
    {
        
        //TODO:Player��Sight����ɔ�������̂�tag��ҏW����
        
        private void OnTriggerEnter2D(Collider2D collision)
        {
            //���� Enter��Exit����ɔ�������ꍇ�� project settings -> physics2d -> Layer Collision Matrix �� Steath �� Steath �� �`�F�b�N��t����
            //player�ȊO�����O
            if (collision.tag != "Player") return;
            Debug.Log("Enter");
            //Debug.Log(collision.name);
            //collision.gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
            //collision.gameObject.layer = LayerMask.NameToLayer("Stealth");
            //���C���[��StealthMode�ɕύX(stealth�̓��C���[�Փ˃}�g���b�N�X��Enemy���ƏՓ˂��Ȃ��ݒ�ɂ��Ă���)

            PlayerInterFace player = collision.gameObject.GetComponent<PlayerInterFace>();
            player.transitionStealthState();
        }
        
        
        
        private void OnTriggerExit2D(Collider2D collision)
        {
            
            if (collision.tag != "Player") return;
            Debug.Log("Exit");
            //Debug.Log(collision.name);
            //TODO:����state�Ɉړ�����ۂ̊֐�or�N���X����肻�̒��ɂ��̏���������
            collision.gameObject.layer = LayerMask.NameToLayer("Player");
            //���C���[��StealthMode�ɕύX(stealth�̓��C���[�Փ˃}�g���b�N�X��Enemy���ƏՓ˂��Ȃ��ݒ�ɂ��Ă���)
            //PlayerInterFace player = collision.gameObject.GetComponent<PlayerInterFace>();
            //player.transitionPitfallState();
        }
        
    }
}
