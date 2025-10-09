using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenInventaire : MonoBehaviour
{
    public GameObject Inventaire;
    public Button openPanel;
    public Button closePanel;

    private void Start()
    {
        openPanel.onClick.AddListener(OpenPanel);
        closePanel.onClick.AddListener(ClosePanel);
    }

    public void OpenPanel()
    {
        if(Inventaire != null)
        {
            Inventaire.SetActive(true);
        }
    }

    public void ClosePanel()
    {
        if (Inventaire != null)
        {
            Inventaire.SetActive(false);
        }
    }
}
