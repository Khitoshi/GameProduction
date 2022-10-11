using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MoveSpeed;

    private SpriteRenderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;
        if (Input.GetKey("left") || Input.GetKey(KeyCode.A))
        {
            position.x -= MoveSpeed;
            renderer.flipX = false;
        }
        else if (Input.GetKey("right") || Input.GetKey(KeyCode.D))
        {
            position.x += MoveSpeed;
            renderer.flipX = true;
        }
        else if (Input.GetKey("up") || Input.GetKey(KeyCode.W))
        {
            position.y -= MoveSpeed;
            
        }
        else if (Input.GetKey("down") || Input.GetKey(KeyCode.S))
        {
            position.y += MoveSpeed;
            
        }

        transform.position = position;
    }   
}
