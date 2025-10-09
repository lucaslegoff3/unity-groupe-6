using UnityEngine;
using TMPro; // si tu utilises TextMeshPro
using UnityEngine.EventSystems;

public class PasteIntoHole : MonoBehaviour, IPointerClickHandler
{
    private TMP_InputField inputField;

    private void Awake()
    {
        inputField = GetComponent<TMP_InputField>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!string.IsNullOrEmpty(ClipboardManager.clipboardText))
        {
            inputField.text = ClipboardManager.clipboardText;
        }
    }
}
