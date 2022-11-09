using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Experimental.Rendering.Universal;
using System.Collections.ObjectModel;

namespace Player
{

    public class PlayerFOV : MonoBehaviour
    {
        [SerializeField] 
        private float Angle;
    
        //���E�̋���
        private CircleCollider2D circle_collider;
        
        //���E�\���p��Light(��ŕʂ̃t�@�C���Ɉڂ�)
        [SerializeField]
        private new Light2D light;
        
        private Player player;
        
        //onTriggerStay���Ɏg�p����tag
        private readonly ReadOnlyCollection<string> TriggerTag = Array.AsReadOnly<string>(new string[] {
            "Enemy"
        });
    
        // Start is called before the first frame update
        void Start()
        {
            //light = GetComponentInChildren<Light2D>();
            circle_collider = GetComponent<CircleCollider2D>();
            player = GetComponent<Player>();
        }
    
        // Update is called once per frame
        void Update()
        {
            
            /*
            float light_radius = circle_collider.radius;
            light.pointLightInnerRadius =
                light.pointLightOuterRadius = light_radius;
    
            float light_angle = Angle * 2;
            light.pointLightInnerAngle =
                light.pointLightOuterAngle = light_angle;   
            */
        }
    
        private void OnTriggerStay2D(Collider2D other)
        {
            return;
            //other���g���K�[�̃^�O���������āA-1��(�Ȃ�)�ꍇ�Ԃ�
            if (!TriggerTag.Contains(other.tag)) return;
            
            //���E�̊p�x���Ɏ��܂��Ă��邩
            Vector3 pos_delta = other.transform.position - this.transform.position;
            Vector3 direction = player.GetPlayerDirection().GetDirection();
            float target_angle = Vector3.Angle(direction, pos_delta);
    
            //target_angle��angle�Ɏ��܂��Ă��Ȃ��ꍇ�Ԃ�
            if (target_angle >= Angle)
            {
                //ObjectIndication(other.GetComponent<SpriteRenderer>(), 0);
                return;
            }
            
            //�g���K�[�̃^�O��RayCast���s��
            foreach(string tag in TriggerTag)
            {
                int layer_mask = LayerMask.GetMask(tag);
                float light_radius = circle_collider.radius;
                RaycastHit2D hit = Physics2D.Raycast(transform.position, pos_delta, light_radius, layer_mask);
                if (hit.collider == other)
                {
                    //Debug.Log(hit.transform.name);
                    Debug.DrawRay(transform.position, pos_delta);
                    //�I�u�W�F�N�g�̓����x�ύX
                    //ObjectIndication(other.GetComponent<SpriteRenderer>(), 1);
                    //�����Ɏ��E�ɓ��������Ɏg����������������
                }
            }
        }
    
        /*
        private void OnTriggerExit2D(Collider2D other)
        {
            if(other.tag == "Enemy")
            {
                ObjectIndication(other.GetComponent<SpriteRenderer>(), 0);
            }
        }
        */
        private void ObjectIndication(SpriteRenderer spr,float alpha)
        {
            Color color = spr.color;
            spr.color = new Color(color.r, color.g, color.b, alpha);
        }
    
        #region Debug
        private void OnGUI()
        {
        }
        #endregion
    }
}

