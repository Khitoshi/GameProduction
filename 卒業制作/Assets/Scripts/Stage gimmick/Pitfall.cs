using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pitfall : MonoBehaviour
{

    // Update is called once per frame
    void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D collsion)
    {
        if(collsion.gameObject.tag == "Player")
        {
           
            PlayerInterFace player = collsion.gameObject.GetComponent<PlayerInterFace>();
            player.transitionPitfallState();

        }
    }

    private void OnTriggerExit2D(Collider2D collsion)
    {
        if (collsion.gameObject.tag == "Player")
        {

            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("otosiana_2");
        }
    }


}

