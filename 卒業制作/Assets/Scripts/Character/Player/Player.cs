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
        public PlayerInput player_input_ { get; private set; }
        public PlayerMovement player_movement_ { get; private set; }
        public PlayerDirection player_direction_ { get; private set; }
            
        // Start is called before the first frame update
        void Start()
        {
            player_input_ = GetComponent<PlayerInput>();
            player_direction_ = GetComponent<PlayerDirection>();
            player_movement_ = GetComponent<PlayerMovement>();
        }
    
        // Update is called once per frame
        void Update()
        {
        }
    }
}
