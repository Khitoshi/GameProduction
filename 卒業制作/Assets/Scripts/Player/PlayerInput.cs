using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerInput : MonoBehaviour
    {

<<<<<<< HEAD
        [HideInInspector] public float horizontal { get; private set; }


        [HideInInspector] public float vertical { get; private set; }
=======
        private float horizontal;
        private float vertical;
>>>>>>> 0165b3f4b4af5944a1667128ad4f881f25519e0e

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

    }
}
