using TMPro;
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

    [Header("Description")]
    [SerializeField] private TextMeshProUGUI mainTitleText;
    [SerializeField] private TextMeshProUGUI mainDescriptionText;

    [Header("Effet de survol")]
    [SerializeField] private float hoverScale = 1.1f;
    [SerializeField] private float scaleSpeed = 8f;

    private Vector3 originalScale;
    private bool isHovered = false;

    public string ID => id;
    public string ObjectName => objectName;
    public string Description => description;
    public Sprite InventorySprite => inventorySprite;
    public bool IsClicked => isClicked;

    private void Awake()
    {
        originalScale = transform.localScale;
    }

    private void Update()
    {
        if (OpenInventaire.IsInventoryOpen)
        {
            return;
        }

        Vector3 targetScale = isHovered ? originalScale * hoverScale : originalScale;
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime * scaleSpeed);
    }

    private void OnMouseEnter()
    {
        if (!OpenInventaire.IsInventoryOpen)
            isHovered = true;
    }

    private void OnMouseExit()
    {
        isHovered = false;
    }

    public virtual void OnClick()
    {
        if (isClicked) return;

        if (OpenInventaire.IsInventoryOpen)
        {
            Debug.Log("Inventaire ouvert — clic désactivé !");
            return;
        }

        isClicked = true;
        Debug.Log($"Objet {objectName} cliqué !");

        InventoryManager.Instance.AddToInventory(this);

        if (InventoryUI.Instance != null && InventoryUI.Instance.gameObject != null)
        {
            InventoryUI.Instance.RefreshUI();
        }
        else
        {
            Debug.LogWarning("InventoryUI.Instance est détruit ou manquant, RefreshUI ignoré.");
        }

        ShowMainDescription();
        HandleClick();
    }
    private void ShowMainDescription()
    {
        if (mainTitleText == null || mainDescriptionText == null)
        {
            Debug.LogWarning($"[ClickableObject] Description principale non configurée pour {name}");
            return;
        }

        mainTitleText.text = objectName;
        mainDescriptionText.text = description;

        Debug.Log($"[ClickableObject] Description mise à jour : {objectName}");
    }


    protected virtual void HandleClick()
    {
        gameObject.SetActive(false);
    }
}
