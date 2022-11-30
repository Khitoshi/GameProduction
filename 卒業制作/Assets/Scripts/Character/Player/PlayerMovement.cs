using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField]
        public float moveSpeed_ ;

        private Rigidbody2D rigidbody2d_;

        Player player_;

        void Start()
        {
            player_ = GetComponent<Player>();
            rigidbody2d_ = GetComponent<Rigidbody2D>();
        }
    
        // Update is called once per frame
        void Update()
        {
        }

        void FixedUpdate()
        {
            float rawHrizontal = player_.player_input_.horizontal_;
            float rawVertical = player_.player_input_.vertical_;

            float horizontal = rawHrizontal * Time.deltaTime;
            float vertical = rawVertical * Time.deltaTime;
            //Vector3 position = new Vector3(0, 0, 0);
            Vector3 position = this.transform.position;

            position.x += horizontal * moveSpeed_;
            position.y += vertical * moveSpeed_;
            transform.position = position;
            rigidbody2d_.MovePosition(transform.position);
        }
    }
}
