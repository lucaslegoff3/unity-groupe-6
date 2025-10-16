using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using System.Collections;
using UnityEngine.UI;

public class ClickableText : MonoBehaviour, IPointerClickHandler
{
    [Header("Composants")]
    public TextMeshProUGUI text;
    public GameObject copiedMessage;

    [Header("Notification")]
    public GameObject panelNotification;
    [SerializeField] private TextMeshProUGUI texteNotification;

    [SerializeField] private float delay = 4f;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Camera cam = null;
        if (text.canvas.renderMode == RenderMode.ScreenSpaceCamera)
        {
            cam = text.canvas.worldCamera;
        }
        audioManager.PlaySFX(audioManager.click);

        int linkIndex = TMP_TextUtilities.FindIntersectingLink(text, eventData.position, cam);

        if (linkIndex != -1)
        {
            TMP_LinkInfo linkInfo = text.textInfo.linkInfo[linkIndex];
            string copiedText = linkInfo.GetLinkText();

            ClipboardManager.clipboardText = copiedText;

            if (panelNotification != null)
            {
                panelNotification.SetActive(true);

                if (texteNotification != null)
                    texteNotification.text ="\"" + copiedText + "\" has been copied.";

                StartCoroutine(HideNotificationAfterDelay());
            }

            Debug.Log("Texte copié : " + copiedText);
        }
    }

    private IEnumerator HideNotificationAfterDelay()
    {
        yield return new WaitForSeconds(delay);
        panelNotification.SetActive(false);
    }
}
