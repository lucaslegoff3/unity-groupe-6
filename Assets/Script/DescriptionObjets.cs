using TMPro;
using UnityEngine;

[System.Serializable]
public class DescriptionObjets : MonoBehaviour
{
    [Header("Informations de base")]
    [SerializeField] private string objectName;
    [TextArea][SerializeField] private string description;

    [Header("Description principale")]
    [SerializeField] private TextMeshProUGUI mainTitleText;
    [SerializeField] private TextMeshProUGUI mainDescriptionText;

    private void OnMouseDown()
    {
        OnClick();
    }

    public virtual void OnClick()
    {
        if (mainTitleText != null)
            mainTitleText.text = objectName;

        if (mainDescriptionText != null)
            mainDescriptionText.text = description;

        Debug.Log($"Description mise à jour pour {objectName}");
    }
}
