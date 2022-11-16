using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Goal : MonoBehaviour
{
    void Update()
    {
            if (gameObject.tag == "Player")
            {
                SceneManager.LoadScene("Test_Stage2");
            }
    }
}
