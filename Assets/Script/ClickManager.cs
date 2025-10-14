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
        // R�cup�re le GraphicRaycaster sur ton Canvas
        raycaster = FindObjectOfType<GraphicRaycaster>();
        eventSystem = FindObjectOfType<EventSystem>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PointerEventData pointerData = new PointerEventData(eventSystem)
            {
                position = Input.mousePosition
            };

            List<RaycastResult> results = new List<RaycastResult>();
            raycaster.Raycast(pointerData, results);

            // V�rifie les �l�ments touch�s
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
}
