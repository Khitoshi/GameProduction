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
        public PlayerInput playerInput { get; private set; }
        public PlayerMovement playerMovement { get; private set; }
        public PlayerDirection playerDirection { get; private set; }
        // Start is called before the first frame update
        void Start()
        {
            playerInput = GetComponent<PlayerInput>();
            playerDirection = GetComponent<PlayerDirection>();
            playerMovement = GetComponent<PlayerMovement>();
        }
    
        // Update is called once per frame
        void Update()
        {
            
        }
    }
}
