using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] 
        private float moveSpeed;

        private Player player;
        // Start is called before the first frame update
        void Start()
        {
            player = GetComponent<Player>();
        }
    
        // Update is called once per frame
        void Update()
        {
            Vector3 position = new Vector3(0, 0, 0);
            float horizontal    =   player.GetPlayerInput().GetHorizontal() * Time.deltaTime;
            float vertical      =   player.GetPlayerInput().GetVertical() * Time.deltaTime;
  
            position.x += horizontal    *   moveSpeed;
            position.y += vertical      *   moveSpeed;
            transform.position += position;
        }
    }
}
