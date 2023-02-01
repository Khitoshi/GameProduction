using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pitfall : MonoBehaviour
{
    private Gauge gauge_;

    // Update is called once per frame
    void Start()
    {
        gauge_ = transform.parent.GetChild(2).GetComponent<Gauge>();
    }

    private void OnTriggerEnter2D(Collider2D collsion)
    {
        if(collsion.gameObject.tag == "Player")
        {
           
            PlayerInterFace player = collsion.gameObject.GetComponent<PlayerInterFace>();
            player.transitionPitfallState();

            gauge_.is_player_hit_ = true;
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

