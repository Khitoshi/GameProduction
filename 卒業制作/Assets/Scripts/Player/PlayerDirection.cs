using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

namespace Player
{
    public class PlayerDirection : MonoBehaviour
    {
        // Start is called before the first frame update        
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
        }

        #if UNITY_EDITOR
        private void OnGUI()
        {
            //GUI.Box(new Rect(20, 20, 150, 20), "horizontal: " + $"{horizontal}");
            //GUI.Box(new Rect(20, 40, 150, 20), "vertical: " + $"{vertical}");
        }
        #endif
    }
}

