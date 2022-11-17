using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField]
        public float moveSpeed ;

        private Rigidbody2D rigidbody2d;

        
        //private  float horizontal ;
        //private float vertical;
        
        //private Player player;
        // Start is called before the first frame update

        Player player;

        void Start()
        {
            player = GetComponent<Player>();
            rigidbody2d = GetComponent<Rigidbody2D>();
        }
    
        // Update is called once per frame
        void Update()
        {
            /*
            float rawHrizontal = GetComponent<Player>().playerInput.horizontal;
            float rawVertical = GetComponent<Player>().playerInput.vertical;
            
            Vector3 position = transform.position;

            float horizontal = rawHrizontal * Time.deltaTime;
            float vertical = rawVertical * Time.deltaTime;

            //float horizontal    =   player.playerInput.horizontal * Time.deltaTime;
            //float vertical      =   player.playerInput.vertical * Time.deltaTime;
  
            position.x += horizontal    *   moveSpeed;
            position.y += vertical      *   moveSpeed;

            transform.position = position;

            */

             //horizontal    =   player.playerInput.horizontal * Time.deltaTime;
             //vertical      =   player.playerInput.vertical * Time.deltaTime;
        }
        void FixedUpdate()
        {
            float rawHrizontal = player.playerInput.horizontal;
            float rawVertical = player.playerInput.vertical;

            float horizontal = rawHrizontal * Time.deltaTime;
            float vertical = rawVertical * Time.deltaTime;
            //Vector3 position = new Vector3(0, 0, 0);
            Vector3 position = this.transform.position;

            position.x += horizontal * moveSpeed;
            position.y += vertical * moveSpeed;
            transform.position = position;
            rigidbody2d.MovePosition(transform.position);
        }
    }
}
