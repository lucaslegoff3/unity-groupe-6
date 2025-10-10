using UnityEngine;
using UnityEngine.UI;

public class OpenDescObject : MonoBehaviour
{
    public GameObject descObject;
    public Button openDescObject;
    public Button closeDescObject;

    [Header("Décalage optionnel (en pixels)")]
    public Vector3 offset = new Vector3(0f, -80f, 0f); // tu peux ajuster depuis l'inspecteur

    private Canvas mainCanvas;

    private void Start()
    {
        openDescObject.onClick.AddListener(OpenDesc);
        closeDescObject.onClick.AddListener(CloseDesc);

        mainCanvas = GetComponentInParent<Canvas>();
    }

    public void OpenDesc()
    {
        // Ferme les autres panneaux
        OpenDescObject[] allPanels = FindObjectsOfType<OpenDescObject>();
        foreach (OpenDescObject panel in allPanels)
        {
            if (panel != this && panel.descObject.activeSelf)
                panel.descObject.SetActive(false);
        }

        if (descObject != null)
        {
            if (mainCanvas != null)
                descObject.transform.SetParent(mainCanvas.transform, true);
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                mainCanvas.transform as RectTransform,
                openDescObject.transform.position,
                mainCanvas.worldCamera,
                out Vector2 localPoint
            );

            descObject.GetComponent<RectTransform>().anchoredPosition = localPoint + (Vector2)offset;
            descObject.transform.SetAsLastSibling();
            descObject.SetActive(true);
        }
    }

    public void CloseDesc()
    {
        if (descObject != null)
            descObject.SetActive(false);
    }
}
