using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScene : MonoBehaviour
{

    private Scene _thisScene;
    
    private void Awake()
    {
        _thisScene = SceneManager.GetActiveScene();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(_thisScene.name);
        }
    }
}
