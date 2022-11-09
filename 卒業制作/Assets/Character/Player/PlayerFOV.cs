using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Experimental.Rendering.Universal;

public class PlayerFOV : MonoBehaviour
{
    [SerializeField] private float Angle;

    new Light2D light;
    //light.
    CircleCollider2D circle_collider;
    // Start is called before the first frame update
    void Start()
    {
        light = GetComponentInChildren<Light2D>();
        circle_collider = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float light_radius = circle_collider.radius / 10;
        light.pointLightInnerRadius =
            light.pointLightOuterRadius = light_radius;

        float light_angle = Angle * 2;
        light.pointLightInnerAngle =
            light.pointLightOuterAngle = light_angle;
    }

    private void OnTriggerStay2D(Collider2D other)
    {   
<<<<<<< HEAD
=======
        //name = "0";
>>>>>>> Enemy
        if (other.gameObject.tag == "Enemy") //Ž‹ŠE‚Ì”ÍˆÍ“à‚Ì“–‚½‚è”»’è
        {
            //Ž‹ŠE‚ÌŠp“x“à‚ÉŽû‚Ü‚Á‚Ä‚¢‚é‚©
            Vector3 pos_delta = other.transform.position - this.transform.position;
            float target_angle = Vector3.Angle(this.transform.up, pos_delta);

            SpriteRenderer sprite_renderer = other.GetComponent<SpriteRenderer>();
            Color color = new Color(
                sprite_renderer.color.r,
                sprite_renderer.color.g,
                sprite_renderer.color.b,
                0);

            if (target_angle < Angle) //target_angle‚ªangle‚ÉŽû‚Ü‚Á‚Ä‚¢‚é‚©‚Ç‚¤‚©
            {
                int layer_mask = LayerMask.GetMask("Enemy");
                float light_radius = circle_collider.radius / 10;
                
                RaycastHit2D hit = Physics2D.Raycast(transform.position, pos_delta, light_radius, layer_mask);
                if (hit.collider == other)
                {
                    sprite_renderer.color = new Color(color.r, color.g, color.b, 1);
                    Debug.DrawRay(transform.position, pos_delta);
                    //Debug.Log(hit.collider.name);
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            SpriteRenderer sprite_renderer = other.GetComponent<SpriteRenderer>();
            Color color = new Color(
            sprite_renderer.color.r,
            sprite_renderer.color.g,
            sprite_renderer.color.b,
            0);
            sprite_renderer.color = new Color(color.r, color.g, color.b, 0);
        }
    }


    #region Debug
    private void OnGUI()
    {
        //GUI.Box(new Rect(20, 20, 150, 23), "Name: "+$"{}");
        // Œ‹‰Ê•\Ž¦
    }
    #endregion
}
