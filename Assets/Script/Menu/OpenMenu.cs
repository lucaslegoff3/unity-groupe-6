using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OpenMenu : MonoBehaviour
{
    public Button openMenuButton;
    public Button closeMenuButton;

    [Header("Panels")]
    public GameObject menuPanel;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Start()
    {
        openMenuButton.onClick.AddListener(OpenPanelMenu);
        closeMenuButton.onClick.AddListener(ClosePanelMenu);
    }

    public void OpenPanelMenu()
    {
        Debug.Log("Ouverture du panel menu");
        if (menuPanel != null)
            menuPanel.SetActive(true);
            audioManager.PlaySFX(audioManager.click);
    }

    public void ClosePanelMenu()
    {
        Debug.Log("Fermeture du panel menu");
        if (menuPanel != null)
            menuPanel.SetActive(false);
    }
}