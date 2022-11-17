using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

namespace Player
{
    public class PlayerDirection : MonoBehaviour
    {
        [SerializeField]
        private new Light2D light;

        private float horizontal = 0;
        private float vertical = 0;

        private Vector3 direction;

        // Start is called before the first frame update
        private Player player;
        void Start()
        {
            light = GetComponentInChildren<Light2D>();

            direction = transform.up;

            player = GetComponent<Player>();
        }

        // Update is called once per frame
        void Update()
        {
            //horizontal -90~90(…•½)
            //vertical 0~180(‚’¼)
            horizontal = player.playerInput.horizontal;
            vertical = player.playerInput.vertical;

            Quaternion rotation = light.transform.rotation;
            
            //Right
            if (horizontal > 0)//R
            {
                rotation = Quaternion.Euler(0, 0, -90);
                direction = transform.right;
            }

            //Left
            if(horizontal < 0)//L
            {
                rotation = Quaternion.Euler(0, 0, 90);
                direction = -transform.right;
            }

            //Up
            if(vertical > 0)//U
            {
                rotation = Quaternion.Euler(0, 0, 0);
                direction = transform.up;
            }

            //Down
            if (vertical < 0)
            {
                rotation = Quaternion.Euler(0, 0, 180);
                direction = -transform.up;
            }
            light.transform.rotation = rotation;
            
        }

        #if UNITY_EDITOR
        private void OnGUI()
        {
            GUI.Box(new Rect(20, 20, 150, 20), "horizontal: " + $"{horizontal}");
            GUI.Box(new Rect(20, 40, 150, 20), "vertical: " + $"{vertical}");
        }
        #endif

        
        public Vector3 GetDirection()
        {
            return direction;
        }

    }
}

