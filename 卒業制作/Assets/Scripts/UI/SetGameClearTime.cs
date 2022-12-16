using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetGameClearTime : MonoBehaviour
{
    [SerializeField] private Text clear_time;
    // Start is called before the first frame update
    void Start()
    {
        clear_time.text = "0.00";
        clear_time.text = Time.time.ToString("0.00");
    }

}
