using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrapMove : CharacterMove
{
    private int KeyCount = 0;
    private int MaxCount = 7;

    void Start()
    {
        KeyCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        pitfallAct();
    }

    private void pitfallAct()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            KeyCount++;
            if(KeyCount>=MaxCount)
            {
                KeyCount = 0;

            }
        }
    }
}
