using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Experimental.Rendering.Universal;
using System.Collections.ObjectModel;

namespace Player
{
    //PlayeréãñÏäpèàóù
    public class PlayerFOV : MonoBehaviour
    {
        //RayCastëŒâûtag
        private readonly ReadOnlyCollection<string> trigger_tag_ = Array.AsReadOnly<string>(new string[] {
            "Enemy"
        });
    
        // Start is called before the first frame update
        void Start()
        {
        }
    
        // Update is called once per frame
        void Update()
        {
        }
    
        private void OnTriggerStay2D(Collider2D other)
        {
        }

        #if UNITY_EDITOR
        private void OnGUI()
        {
        }
        #endif
    }
}

