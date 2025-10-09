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
        foreach (Button slot in slots)
        {
            Image img = slot.GetComponent<Image>();
            if (img != null && img.sprite == null) // slot vide
            {
                img.sprite = newItem.InventorySprite; // <-- c'est ici que l'image de ton objet est prise
                img.color = Color.white; // rend l'image visible
                slot.interactable = true;
                return;
            }
        }
    }

}
