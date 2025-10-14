using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using System.Collections;

public class ClickableText : MonoBehaviour, IPointerClickHandler
{
    [Header("Composants")]
    public TextMeshProUGUI text;
    public GameObject copiedMessage; // Un Text ou une UI pour afficher "Texte copié !"

    [Header("Paramètres")]
    public float messageDuration = 2f; // Durée d'affichage du message

    public void OnPointerClick(PointerEventData eventData)
    {
        Camera cam = null;
        if (text.canvas.renderMode == RenderMode.ScreenSpaceCamera)
        {
            cam = text.canvas.worldCamera;
        }

        // Trouver si on clique sur un lien
        int linkIndex = TMP_TextUtilities.FindIntersectingLink(text, eventData.position, cam);

        if (linkIndex != -1)
        {
            TMP_LinkInfo linkInfo = text.textInfo.linkInfo[linkIndex];
            string copiedText = linkInfo.GetLinkText();

            // Copie dans le presse-papiers
            ClipboardManager.clipboardText = copiedText;
            Debug.Log("Texte copié : " + copiedText);

            // Afficher message visuel
            if (copiedMessage != null)
            {
                StartCoroutine(ShowCopiedMessage());
            }
        }
    }

    private IEnumerator ShowCopiedMessage()
    {
        copiedMessage.SetActive(true);
        yield return new WaitForSeconds(messageDuration);
        copiedMessage.SetActive(false);
    }
}
