using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    public static InventoryUI Instance;

    [Header("Références")]
    [SerializeField] private Transform slotsParent;

    private List<Button> slots = new List<Button>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        // Récupère tous les slots (boutons)
        foreach (Transform child in slotsParent)
        {
            Button slotButton = child.GetComponent<Button>();
            if (slotButton != null)
            {
                slots.Add(slotButton);

                // Réinitialiser visuellement le slot
                Image img = slotButton.GetComponent<Image>();
                if (img != null)
                {
                    img.sprite = null;
                    img.color = new Color(1, 1, 1, 0);
                }

                slotButton.interactable = false;

                // Cache le panel interne
                Transform panel = slotButton.transform.Find("Panel");
                if (panel != null)
                    panel.gameObject.SetActive(false);
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

                // Met à jour le panel interne
                Transform panel = slot.transform.Find("Panel");
                if (panel != null)
                {
                 
                    Text titleText = panel.Find("Titre")?.GetComponent<Text>();
                    TextMeshProUGUI descText = panel.Find("Description")?.GetComponent<TextMeshProUGUI>();

                    if (titleText) titleText.text = item.ObjectName;
                    if (descText) descText.text = item.Description;

                    panel.gameObject.SetActive(false); // Caché par défaut
                }

                // Ajoute un listener pour ouvrir le panel au clic
                slot.onClick.RemoveAllListeners();
                slot.onClick.AddListener(() =>
                {
                    Transform panel = slot.transform.Find("Panel");
                    if (panel != null)
                        panel.gameObject.SetActive(!panel.gameObject.activeSelf); // toggle affichage
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

                Transform panel = slot.transform.Find("Panel");
                if (panel != null)
                    panel.gameObject.SetActive(false);
            }
        }
    }
}
