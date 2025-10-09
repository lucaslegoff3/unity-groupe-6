using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenDescObject : MonoBehaviour
{
    [Header("R�f�rences")]
    public GameObject descObject;
    public Button openDescObject;
    public Button closeDescObject;

    // Liste statique de tous les scripts actifs
    private static List<OpenDescObject> allPanels = new List<OpenDescObject>();

    private void Awake()
    {
        // On enregistre chaque instance au d�marrage
        allPanels.Add(this);
    }

    private void OnDestroy()
    {
        // On la retire proprement si l�objet est d�truit
        allPanels.Remove(this);
    }

    private void Start()
    {
        openDescObject.onClick.AddListener(OpenDesc);
        closeDescObject.onClick.AddListener(CloseDesc);

        // Par s�curit�, le panel est ferm� au d�part
        if (descObject != null)
            descObject.SetActive(false);
    }

    public void OpenDesc()
    {
        if (descObject == null) return;

        // Ferme tous les autres panneaux avant d'ouvrir celui-ci
        foreach (var panel in allPanels)
        {
            if (panel != this && panel.descObject != null)
            {
                panel.descObject.SetActive(false);
            }
        }

        // Active celui de ce slot
        descObject.SetActive(true);
    }

    public void CloseDesc()
    {
        if (descObject != null)
        {
            descObject.SetActive(false);
        }
    }
}
