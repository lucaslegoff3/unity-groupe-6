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

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Start()
    {
        restartButton.onClick.AddListener(RestartGame);
        quitButton.onClick.AddListener(QuitGame);
        rulesButton.onClick.AddListener(OpenRules);
        closeRulesButton.onClick.AddListener(CloseRules);

        if (rulesPanel != null)
            rulesPanel.SetActive(false);
    }

    public void RestartGame()
    {
        Debug.Log("Réinitialiser le jeu...");
        audioManager.PlaySFX(audioManager.click);
        SceneManager.LoadScene("Intro");
    }

    public void QuitGame()
    {
        Debug.Log("Quitter le jeu...");
        audioManager.PlaySFX(audioManager.click);
        Application.Quit();
    }

    public void OpenRules()
    {
        Debug.Log("Ouverture du panel des règles");
        if (rulesPanel != null)
        {
            audioManager.PlaySFX(audioManager.click);
            rulesPanel.SetActive(true);
        }
    }

    public void CloseRules()
    {
        Debug.Log("Fermeture du panel des règles");
        if (rulesPanel != null)
        {
            audioManager.PlaySFX(audioManager.click);
            rulesPanel.SetActive(false);
        }
    }
}
