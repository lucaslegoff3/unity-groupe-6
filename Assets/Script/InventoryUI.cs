using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    public static InventoryUI Instance;

    [Header("Références")]
    [SerializeField] private Transform slotsParent;
    [SerializeField] private GameObject globalDescriptionPanel;
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI descriptionText;

    private readonly List<Button> slots = new();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        foreach (Transform child in slotsParent)
        {
            if (child.TryGetComponent<Button>(out var slotButton))
            {
                slots.Add(slotButton);

                if (slotButton.TryGetComponent<Image>(out var img))
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

                slot.onClick.RemoveAllListeners();

                slot.onClick.AddListener(() =>
                {
                    ShowGlobalDescription(item);
                });
            }
            else
            {
                if (img != null)
                {
                    img.sprite = null;
                    img.color = new Color(1, 1, 1, 0);
                }

                slot.interactable = false;
            }
        }
    }

    private void ShowGlobalDescription(ClickableObject item)
    {
        if (globalDescriptionPanel == null) return;

        if (titleText != null)
            titleText.text = item.ObjectName;

        if (descriptionText != null)
            descriptionText.text = item.Description;

        globalDescriptionPanel.SetActive(true);

        globalDescriptionPanel.transform.SetAsLastSibling();
    }
    public void HideGlobalDescription()
    {
        if (globalDescriptionPanel != null)
            globalDescriptionPanel.SetActive(false);
    }

}
