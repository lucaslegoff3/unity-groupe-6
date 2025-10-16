using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using static Unity.Collections.AllocatorManager;

public class PasteIntoHole : MonoBehaviour, IPointerClickHandler
{
    private TMP_InputField inputField;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        inputField = GetComponent<TMP_InputField>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("value of clipboard manager : " + ClipboardManager.clipboardText);
        if (!string.IsNullOrEmpty(ClipboardManager.clipboardText))
        {
            inputField.text = ClipboardManager.clipboardText;
            audioManager.PlaySFX(audioManager.click);
        }
    }
}
