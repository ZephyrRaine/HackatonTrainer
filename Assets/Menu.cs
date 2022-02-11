using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button quitButton;

    // Start is called before the first frame update
    void Start()
    {
        startButton.Select();
        startButton.onClick.AddListener(StartGame);
        quitButton.onClick.AddListener(Quit);
    }

    public void StartGame()
    {
        SceneManager.LoadSceneAsync(1);
        startButton.enabled = quitButton.enabled = false;

    }

    public void Quit()
    {
        Application.Quit();
    }
}