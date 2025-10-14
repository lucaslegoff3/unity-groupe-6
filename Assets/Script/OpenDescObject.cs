using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class OpenDescObject : MonoBehaviour
{
    [Header("Références")]
    public GameObject descObject;
    public Button openDescObject;

    private static readonly List<OpenDescObject> allPanels = new();

    private void Awake()
    {
        allPanels.Add(this);
    }

    private void OnDestroy()
    {
        allPanels.Remove(this);
    }

    private void Start()
    {
        openDescObject.onClick.AddListener(OpenDesc);

        if (descObject != null)
            descObject.SetActive(false);
    }

    public void OpenDesc()
    {
        if (descObject == null) return;

        foreach (var panel in allPanels)
        {
            if (panel != this && panel.descObject != null)
                panel.descObject.SetActive(false);
        }

        descObject.SetActive(true);
        descObject.transform.SetAsLastSibling();

        if (!descObject.TryGetComponent<Canvas>(out var canvas))
        {
            canvas = descObject.AddComponent<Canvas>();
            descObject.AddComponent<GraphicRaycaster>();
        }

        canvas.overrideSorting = true;
        canvas.sortingOrder = 200;
    }


    public void CloseDesc()
    {
        if (descObject != null)
            descObject.SetActive(false);
    }
}
