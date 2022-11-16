using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
<<<<<<< HEAD
        [SerializeField]
        public float moveSpeed ;
=======
        [SerializeField] 
        private float moveSpeed;
        private Rigidbody2D rigidbody2d;

       private  float horizontal ;
        private float vertical;

>>>>>>> 0165b3f4b4af5944a1667128ad4f881f25519e0e

        //private Player player;
        // Start is called before the first frame update

        void Start()
        {
<<<<<<< HEAD
            //   player = GetComponent<Player>();
=======
            player = GetComponent<Player>();
            rigidbody2d = GetComponent<Rigidbody2D>();
>>>>>>> 0165b3f4b4af5944a1667128ad4f881f25519e0e
        }
    
        // Update is called once per frame
        void Update()
        {
<<<<<<< HEAD

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
=======
             horizontal    =   player.GetPlayerInput().GetHorizontal() * Time.deltaTime;
             vertical      =   player.GetPlayerInput().GetVertical() * Time.deltaTime;
>>>>>>> 0165b3f4b4af5944a1667128ad4f881f25519e0e
        }
        void FixedUpdate()
        {
            Vector3 position = new Vector3(0, 0, 0);
            position.x += horizontal * moveSpeed;
            position.y += vertical * moveSpeed;
            transform.position += position;
            rigidbody2d.MovePosition(transform.position);

        }


 
    }
}
