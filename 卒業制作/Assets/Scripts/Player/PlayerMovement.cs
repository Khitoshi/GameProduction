using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField]
        public float moveSpeed ;

        private Rigidbody2D _rigidbody2d;

        Player player;

        void Start()
        {
            player = GetComponent<Player>();
            _rigidbody2d = GetComponent<Rigidbody2D>();
        }
    
        // Update is called once per frame
        void Update()
        {
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
            _rigidbody2d.MovePosition(transform.position);
        }
    }
}
