using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyFOV : MonoBehaviour
{
    [SerializeField] private float angle;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Stay: " + $"{Stay}");
        //State = 0;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        //name = "0"
        if (other.gameObject.tag == "Enemy") //Ž‹ŠE‚Ì”ÍˆÍ“à‚Ì“–‚½‚è”»’è
        {
            //name = "1"
            //Ž‹ŠE‚ÌŠp“x“à‚ÉŽû‚Ü‚Á‚Ä‚¢‚é‚©
            Vector3 posDelta = other.transform.position - this.transform.position;
            float target_angle = Vector3.Angle(this.transform.up, posDelta);

            if (target_angle < angle) //target_angle‚ªangle‚ÉŽû‚Ü‚Á‚Ä‚¢‚é‚©‚Ç‚¤‚©
            {
                Debug.DrawRay(transform.position, posDelta);
                if (Physics.Raycast(this.transform.position, posDelta, out RaycastHit hit)) //Ray‚ðŽg—p‚µ‚Ätarget‚É“–‚½‚Á‚Ä‚¢‚é‚©”»•Ê
                {
                    if (hit.collider == other)
                    {
                        Debug.Log(hit.collider.name);
                    }
                }
            }
        }
    }
}
