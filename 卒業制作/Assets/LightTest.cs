using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var light = GetComponentInChildren<Light2D>();

        light.pointLightInnerAngle = 0;
        light.pointLightOuterAngle = 0;

    }
}
