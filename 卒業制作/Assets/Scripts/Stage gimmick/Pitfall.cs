using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pitfall : MonoBehaviour
{
    public GameObject Obj;
    public bool isFall;

    private PlayerMove player;

    Vector2 velocity;
    [SerializeField] int KeyCount = 0;
    [SerializeField] int MaxCount = 6;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<PlayerMove>();
        rb = GetComponent<Rigidbody2D>();
        isFall = false;
        KeyCount = 0;

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collion)
    {
        // falseの時&そのオブジェクトのタグが以下の時
        if (!isFall && collion.gameObject.CompareTag("FallTile"))
        {
            Debug.Log("second");
            FallProcess();

            if (Input.GetKey(KeyCode.R))
            {
                Debug.Log(KeyCount);
                KeyCount++;
                if (KeyCount >= MaxCount)
                {
                    Debug.Log("再開");
                    

                    isFall = false;
                }
            }

        }
    }

    private void FallProcess()
    {
        Debug.Log("R");
        isFall = true;

        rb.position = Vector3.zero;
    }
   
}

