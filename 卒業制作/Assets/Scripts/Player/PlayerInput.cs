using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerInput : MonoBehaviour
    {

        [HideInInspector] public float horizontal_ { get; private set; }

        [HideInInspector] public float vertical_ { get; private set; }

        // Start is called before the first frame update
        void Start()
        {
        }
    
        // Update is called once per frame
        void Update()
        {
            
            //�␳���|���Ăɐ����A��������肷��
            //horizontal  = Input.GetAxis("Horizontal");
            //vertical    = Input.GetAxis("Vertical");

            //�␳���|�����ɐ����A��������肷��(-1or1)
            horizontal_  = Input.GetAxisRaw("Horizontal");
            vertical_    = Input.GetAxisRaw("Vertical");
        }
    }
}
