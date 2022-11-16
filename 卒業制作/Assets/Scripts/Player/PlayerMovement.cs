using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] 
        private float moveSpeed;
        private Rigidbody2D rigidbody2d;

       private  float horizontal ;
        private float vertical;


        private Player player;
        // Start is called before the first frame update
        void Start()
        {
            player = GetComponent<Player>();
            rigidbody2d = GetComponent<Rigidbody2D>();
        }
    
        // Update is called once per frame
        void Update()
        {
             horizontal    =   player.GetPlayerInput().GetHorizontal() * Time.deltaTime;
             vertical      =   player.GetPlayerInput().GetVertical() * Time.deltaTime;
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
