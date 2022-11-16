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
        }
    
        private void OnTriggerStay2D(Collider2D other)
        {
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

