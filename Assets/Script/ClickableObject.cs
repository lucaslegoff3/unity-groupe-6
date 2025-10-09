using UnityEngine;

[System.Serializable]
public class ClickableObject : MonoBehaviour
{
    [Header("Informations de base")]
    [SerializeField] private string id;
    [SerializeField] private string objectName;
    [TextArea][SerializeField] private string description;

    [Header("Images")]
    [SerializeField] private Sprite worldSprite;     // Image utilis�e dans le jeu
    [SerializeField] private Sprite inventorySprite;

    [Header("�tat")]
    [SerializeField] private bool isClicked = false;

    public string ID => id;
    public string ObjectName => objectName;
    public string Description => description;
    public Sprite WorldSprite => worldSprite;
    public Sprite InventorySprite => inventorySprite;
    public bool IsClicked => isClicked;

    public virtual void OnClick()
    {
        if (isClicked) return;

        isClicked = true;
        Debug.Log($"Objet {objectName} cliqu� !");
        HandleClick();
    }

    protected virtual void HandleClick()
    {
        
    }
}
