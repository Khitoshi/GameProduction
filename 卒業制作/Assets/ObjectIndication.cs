using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectIndication : MonoBehaviour
{
    [SerializeField] Transform self;
    // Start is called before the first frame update
    void Start()
    { 
            Debug.Log(self.gameObject.tag);
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
}
