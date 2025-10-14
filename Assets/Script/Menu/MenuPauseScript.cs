using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPauseScript : MonoBehaviour
{
    [Header("Boutons")]
    public Button restartButton;
    public Button quitButton;
    public Button rulesButton;
    public Button closeRulesButton;

    [Header("Panels")]
    public GameObject rulesPanel;

    private void Start()
    {
        restartButton.onClick.AddListener(RestartGame);
        quitButton.onClick.AddListener(QuitGame);
        rulesButton.onClick.AddListener(OpenRules);
        closeRulesButton.onClick.AddListener(CloseRules);

        // Cache le panel des règles au démarrage
        if (rulesPanel != null)
            rulesPanel.SetActive(false);
    }

    public void RestartGame()
    {
        Debug.Log("Réinitialiser le jeu...");
        SceneManager.LoadScene("Intro");
    }

    public void QuitGame()
    {
        Debug.Log("Quitter le jeu...");
        Application.Quit();
    }

    public void OpenRules()
    {
        Debug.Log("Ouverture du panel des règles");
        if (rulesPanel != null)
            rulesPanel.SetActive(true);
    }

    public void CloseRules()
    {
        Debug.Log("Fermeture du panel des règles");
        if (rulesPanel != null)
            rulesPanel.SetActive(false);
    }
}
