using UnityEngine;
using TMPro; 

public class CopyButtonScript : MonoBehaviour
{
    public TMP_Text sourceText; // si tu utilises TextMeshPro
    public string textToCopy;

    public void CopyText()
    {
        ClipboardManager.clipboardText = textToCopy;
        Debug.Log("Texte copié : " + ClipboardManager.clipboardText);
    }
}
