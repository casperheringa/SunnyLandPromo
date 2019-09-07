using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class RestartGame : MonoBehaviour
{

    //This is for restarting the level when you press R
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            //Reloading the scene
            SceneManager.LoadScene(0);
        }
    }
}
