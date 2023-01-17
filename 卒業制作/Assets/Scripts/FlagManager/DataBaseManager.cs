using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBaseManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public List<FlagDateBase> flag_date_base;
    void Start()
    {
        foreach(FlagDateBase flag in flag_date_base)
        {
            flag.Init();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
