using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField]
        public float moveSpeed ;

        //private Player player;
        // Start is called before the first frame update

        void Start()
        {
            //   player = GetComponent<Player>();
        }
    
        // Update is called once per frame
        void Update()
        {

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
        }
    }
}
