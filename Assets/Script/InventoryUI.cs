using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

        foreach (Button slot in slots)
        {
            Image img = slot.GetComponent<Image>();
            if (img != null)
            {
                img.sprite = null;
                img.color = new Color(1, 1, 1, 0);
                slot.interactable = false;
            }
        }

        for (int i = 0; i < InventoryManager.Instance.inventory.Count && i < slots.Count; i++)
        {
            Image img = slots[i].GetComponent<Image>();
            if (img != null)
            {
                img.sprite = InventoryManager.Instance.inventory[i].InventorySprite;
                img.color = Color.white;
                slots[i].interactable = true;
            }
        }
    }
}
