using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public Button playButton;
    public Button quitButton;

    private void Start()
    {
        playButton.onClick.AddListener(StartGame);
        quitButton.onClick.AddListener(QuitGame);
    }

    private void Update()
    {
        
    }

    public void StartGame()
    {
        Debug.Log("Demarrer le jeu...");
        SceneManager.LoadScene("Video");
    }

    public void QuitGame()
    {
        Debug.Log("Quitter le jeu...");
        Application.Quit();
    }
}