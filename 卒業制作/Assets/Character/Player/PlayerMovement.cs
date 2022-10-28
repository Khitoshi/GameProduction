using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;
        [SerializeField] private Player player;
        // Start is called before the first frame update
        void Start()
        {
            player = GetComponent<Player>();
        }
    
        // Update is called once per frame
        void Update()
        {
            Vector3 position = new Vector3(0, 0, 0);
            position.x += player.GetPlayerInput().GetHorizontal()   *   moveSpeed;
            position.y += player.GetPlayerInput().GetVertical()     *   moveSpeed;
            
            transform.position += position;
        }
    }
}
