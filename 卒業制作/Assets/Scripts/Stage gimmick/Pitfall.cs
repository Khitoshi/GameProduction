using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pitfall : MonoBehaviour
{
    private Gauge gauge_;

    // Update is called once per frame
    void Update()
    {
        gauge_ = GameObject.Find("PitFall/Image2").GetComponent<Gauge>();
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

            //var sprite = GetComponent<SpriteRenderer>().sprite;
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("otosiana_2");
        }
    }


}

