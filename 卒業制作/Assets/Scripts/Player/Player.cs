using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{

    [RequireComponent(typeof(PlayerInput))]
    [RequireComponent(typeof(PlayerMovement))]
    [RequireComponent(typeof(PlayerFOV))]
    [RequireComponent(typeof(PlayerDirection))]
    public class Player : MonoBehaviour
    {
        private PlayerInput playerInput;
        private PlayerDirection playerDirection;
        // Start is called before the first frame update
        void Start()
        {
            playerInput = GetComponent<PlayerInput>();
            playerDirection = GetComponent<PlayerDirection>();
        }
    
        // Update is called once per frame
        void Update()
        {
            
        }

        public PlayerInput GetPlayerInput()
        {
            return playerInput;
        }


        public PlayerDirection GetPlayerDirection()
        {
            return playerDirection;
        }

    }
}
