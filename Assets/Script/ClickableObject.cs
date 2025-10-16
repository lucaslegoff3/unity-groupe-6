using TMPro;
using UnityEngine;
using static UnityEditor.Progress;

[System.Serializable]
public class ClickableObject : MonoBehaviour
{
    [Header("Informations de base")]
    [SerializeField] private string id;
    [SerializeField] private string objectName;
    [TextArea][SerializeField] private string description;

    [Header("Description principale")]
    [SerializeField] private TextMeshProUGUI mainTitleText;
    [SerializeField] private TextMeshProUGUI mainDescriptionText;
    [TextArea][SerializeField] private string descriptionPiece;

    [Header("Image")]
    [SerializeField] private Sprite inventorySprite;
    [SerializeField] private Sprite selectSprite;

    [Header("Audio clip")]
    public AudioClip sound;

    [Header("État")]
    [SerializeField] private bool isClicked = false;

    [Header("Effet de survol")]
    [SerializeField] private float hoverScale = 1.1f;
    [SerializeField] private float scaleSpeed = 8f;

    private Vector3 originalScale;
    private bool isHovered = false;

    public string ID => id;
    public string ObjectName => objectName;
    public string Description => description;
    public Sprite InventorySprite => inventorySprite;
    public Sprite SelectSprite => selectSprite;
    public bool IsClicked => isClicked;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
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
        audioManager.PlaySFX(sound);
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

        if (mainTitleText != null)
            mainTitleText.text = ObjectName;

        if (mainDescriptionText != null)
            mainDescriptionText.text = descriptionPiece;

        HandleClick();
    }


    protected virtual void HandleClick()
    {
        gameObject.SetActive(false);
    }
}
