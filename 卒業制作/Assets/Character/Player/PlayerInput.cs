using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerInput : MonoBehaviour
    {
        private float horizontal;
        private float vertical;
        // Start is called before the first frame update
        void Start()
        {
        }
    
        // Update is called once per frame
        void Update()
        {
            horizontal  = Input.GetAxis("Horizontal") * Time.deltaTime;
            vertical    = Input.GetAxis("Vertical") * Time.deltaTime;
            //Debug.Log("Delta: "+Delta) ;
        }

        public float GetHorizontal()
        {
            return horizontal;
        }

        public float GetVertical()
        {
            return vertical;
        }

    }
}
