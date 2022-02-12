using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public string nextSceneName;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button7))
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
