using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    public static InventoryUI Instance;

    [Header("Références")]
    [SerializeField] private Transform slotsParent;              // Parent des slots (boutons)
    [SerializeField] private GameObject globalDescriptionPanel;  // Le panel global "Description"
    [SerializeField] private TextMeshProUGUI titleText;                     // Texte du titre (UI Text)
    [SerializeField] private TextMeshProUGUI descriptionText;    // Texte de description (TMP)

    private List<Button> slots = new List<Button>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        foreach (Transform child in slotsParent)
        {
            Button slotButton = child.GetComponent<Button>();
            if (slotButton != null)
            {
                slots.Add(slotButton);

                Image img = slotButton.GetComponent<Image>();
                if (img != null)
                {
                    img.sprite = null;
                    img.color = new Color(1, 1, 1, 0);
                }

                slotButton.interactable = false;
            }
        }
    }

    public void RefreshUI()
    {
        if (InventoryManager.Instance == null) return;

        for (int i = 0; i < slots.Count; i++)
        {
            Button slot = slots[i];
            Image img = slot.GetComponent<Image>();

            if (i < InventoryManager.Instance.inventory.Count)
            {
                ClickableObject item = InventoryManager.Instance.inventory[i];

                if (img != null)
                {
                    img.sprite = item.InventorySprite;
                    img.color = Color.white;
                }

                slot.interactable = true;

                // Supprime les anciens listeners pour éviter les doublons
                slot.onClick.RemoveAllListeners();

                // Ajoute un listener pour afficher le panel Description global
                slot.onClick.AddListener(() =>
                {
                    ShowGlobalDescription(item);
                });
            }
            else
            {
                // Slot vide
                if (img != null)
                {
                    img.sprite = null;
                    img.color = new Color(1, 1, 1, 0);
                }

                slot.interactable = false;
            }
        }
    }

    /// <summary>
    /// Affiche le panel global de description avec les infos de l'objet.
    /// </summary>
    private void ShowGlobalDescription(ClickableObject item)
    {
        if (globalDescriptionPanel == null) return;

        // Met à jour les textes
        if (titleText != null)
            titleText.text = item.ObjectName;

        if (descriptionText != null)
            descriptionText.text = item.Description;

        // Affiche le panel
        globalDescriptionPanel.SetActive(true);

        // Le place au-dessus de tout dans la hiérarchie
        globalDescriptionPanel.transform.SetAsLastSibling();
    }
    public void HideGlobalDescription()
    {
        if (globalDescriptionPanel != null)
            globalDescriptionPanel.SetActive(false);
    }
}
