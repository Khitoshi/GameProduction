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
            
            //補正を掛けてに水平、垂直を入手する
            //horizontal  = Input.GetAxis("Horizontal");
            //vertical    = Input.GetAxis("Vertical");

            //補正を掛けずに水平、垂直を入手する(-1~1)
            horizontal  = Input.GetAxisRaw("Horizontal");
            vertical    = Input.GetAxisRaw("Vertical");

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
