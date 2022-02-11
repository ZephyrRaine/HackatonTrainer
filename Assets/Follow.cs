using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Camera camera;
    public int score;

    [SerializeField] private TMP_Text scoreText;
    private void Awake()
    {
        camera = Camera.main;
        Cursor.visible = false;
    }

    private void Update()
    {
        RaycastHit hit;
        Ray ray = camera.ViewportPointToRay(Vector3.one*0.5f);

        if (Physics.Raycast(ray, out hit))
        {
            score++;
            //  SpawnNewsphere();
            // Do something with the object that was hit by the raycast.
        }

        UpdateGUI();
    }
    
    void UpdateGUI()
    {
        scoreText.text = score.ToString();
    }

}
