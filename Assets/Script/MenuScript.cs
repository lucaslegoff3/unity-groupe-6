using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public Button playButton;
    public Button restartButton;
    public Button quitButton;

    private void Start()
    {
        playButton.onClick.AddListener(StartGame);
        quitButton.onClick.AddListener(QuitGame);
        restartButton.onClick.AddListener(RestartGame);
    }

    private void Update()
    {
        
    }

    public void StartGame()
    {
        Debug.Log("Demarrer le jeu...");
        SceneManager.LoadScene("Game");
    }

    public void RestartGame()
    {
        Debug.Log("Réinitialiser le jeu...");
        SceneManager.LoadScene("Game");
    }

    public void QuitGame()
    {
        Debug.Log("Quitter le jeu...");
        Application.Quit();
    }
}