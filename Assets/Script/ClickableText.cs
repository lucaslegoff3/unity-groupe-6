using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class ClickableText : MonoBehaviour, IPointerClickHandler
{
    public TextMeshProUGUI text;

    public void OnPointerClick(PointerEventData eventData)
    {
        Vector3 mousePosition = new Vector3(eventData.position.x, eventData.position.y, 0);

        var linkTaggedText = TMP_TextUtilities.FindIntersectingLink(text, mousePosition, null);

        if (linkTaggedText != -1)
        {
            TMP_LinkInfo linkInfo = text.textInfo.linkInfo[linkTaggedText];
            Debug.Log("link info : " + linkInfo.GetLinkText());

            ClipboardManager.clipboardText = linkInfo.GetLinkText();
            Debug.Log("Texte copié : " + ClipboardManager.clipboardText);
        }
    }
}