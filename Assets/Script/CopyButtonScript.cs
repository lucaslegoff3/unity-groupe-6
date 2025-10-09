using UnityEngine;
using TMPro; 

public class CopyButtonScript : MonoBehaviour
{
    public TMP_Text sourceText; // si tu utilises TextMeshPro

    public void CopyText()
    {
        ClipboardManager.clipboardText = sourceText.text;
        Debug.Log("Texte copié : " + ClipboardManager.clipboardText);
    }
}
