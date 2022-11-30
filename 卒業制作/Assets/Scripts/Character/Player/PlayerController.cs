using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }   

    private void Move()
    {
        Vector2 position = transform.position;
        if (Input.GetKey("left") || Input.GetKey(KeyCode.A))
        {
            position.x -= moveSpeed;
        }
        else if (Input.GetKey("right") || Input.GetKey(KeyCode.D))
        {
            position.x += moveSpeed;
        }

        if (Input.GetKey("up") || Input.GetKey(KeyCode.W))
        {
            position.y -= moveSpeed;

        }
        else if (Input.GetKey("down") || Input.GetKey(KeyCode.S))
        {
            position.y += moveSpeed;
        }
        transform.position = position;
    }
}
