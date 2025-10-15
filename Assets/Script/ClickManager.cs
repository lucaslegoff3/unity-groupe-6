using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.UI;

public class ClickManager : MonoBehaviour
{
    private GraphicRaycaster raycaster;
    private EventSystem eventSystem;

    void Start()
    {
        AssignReferences();
    }

    void Update()
    {
        if (raycaster == null || eventSystem == null)
        {
            AssignReferences();
            if (raycaster == null || eventSystem == null)
                return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            PointerEventData pointerData = new PointerEventData(eventSystem)
            {
                position = Input.mousePosition
            };

            List<RaycastResult> results = new List<RaycastResult>();
            raycaster.Raycast(pointerData, results);

            foreach (RaycastResult result in results)
            {
                var clickable = result.gameObject.GetComponent<ClickableObject>();
                if (clickable != null)
                {
                    clickable.OnClick();
                    break;
                }
            }
        }
    }

    private void AssignReferences()
    {
        raycaster = FindObjectOfType<GraphicRaycaster>();
        eventSystem = FindObjectOfType<EventSystem>();
    }
}
