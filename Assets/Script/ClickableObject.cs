using UnityEngine;

[System.Serializable]
public class ClickableObject : MonoBehaviour
{
    [Header("Informations de base")]
    [SerializeField] private string id;
    [SerializeField] private string objectName;
    [TextArea][SerializeField] private string description;

    [Header("Image")]
    [SerializeField] private Sprite inventorySprite;

    [Header("État")]
    [SerializeField] private bool isClicked = false;

    public string ID => id;
    public string ObjectName => objectName;
    public string Description => description;
    public Sprite InventorySprite => inventorySprite;
    public bool IsClicked => isClicked;

    public virtual void OnClick()
    {
        if (isClicked) return;

        isClicked = true;
        Debug.Log($"Objet {objectName} cliqué !");

        InventoryManager.Instance.AddToInventory(this);

        if (InventoryUI.Instance != null)
            InventoryUI.Instance.RefreshUI();

        HandleClick();
    }

    protected virtual void HandleClick()
    {
        gameObject.SetActive(false);
    }
}
