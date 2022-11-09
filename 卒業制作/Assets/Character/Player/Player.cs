using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(PlayerInput), typeof(PlayerMovement),typeof(PlayerFOV))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private PlayerInput playerInput;
        [SerializeField] private PlayerMovement playerMovement;
        // Start is called before the first frame update
        void Start()
        {
            playerMovement = GetComponent<PlayerMovement>();
            playerInput = GetComponent<PlayerInput>();
        }
    
        // Update is called once per frame
        void Update()
        {
            
        }

        public PlayerInput GetPlayerInput()
        {
            return playerInput;
        }

    }
}
