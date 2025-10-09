using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [Header("Références")]
    [SerializeField] private Transform slotsParent; // Le parent qui contient les slots (panel d’inventaire)

    private List<Button> slots = new List<Button>();

    private void Awake()
    {
        // Récupère tous les boutons enfants (slots)
        foreach (Transform child in slotsParent)
        {
            Button slotButton = child.GetComponent<Button>();
            if (slotButton != null)
            {
                slots.Add(slotButton);

                // Initialise les slots vides
                Image img = slotButton.GetComponent<Image>();
                if (img != null)
                {
                    img.sprite = null;
                    img.color = new Color(1, 1, 1, 0); // rend l’image invisible si vide
                }
                slotButton.interactable = false;
            }
        }
    }

    private void OnEnable()
    {
        InventoryManager.OnItemAdded += AddItemToUI;
    }

    private void OnDisable()
    {
        InventoryManager.OnItemAdded -= AddItemToUI;
    }

    private void AddItemToUI(ClickableObject newItem)
    {
        // Trouve un slot libre
        foreach (Button slot in slots)
        {
            Image img = slot.GetComponent<Image>();
            if (img != null && img.sprite == null)
            {
                img.sprite = newItem.InventorySprite;
                img.color = Color.white; // le rend visible
                slot.interactable = true;

                Debug.Log($"Slot mis à jour avec {newItem.ObjectName}");
                return;
            }
        }

        Debug.LogWarning("Aucun slot libre disponible dans l’inventaire !");
    }
}
