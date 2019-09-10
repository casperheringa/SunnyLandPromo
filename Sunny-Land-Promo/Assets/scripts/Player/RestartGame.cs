using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class RestartGame : MonoBehaviour
{

    //als je op R drukt dat restart de scene
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            //herladen van scene 0
            SceneManager.LoadScene(0);
        }
    }
}
