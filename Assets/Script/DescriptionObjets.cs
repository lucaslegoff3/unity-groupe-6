using TMPro;
using UnityEngine;
using static UnityEditor.Progress;

[System.Serializable]
public class DesriptionObjets : MonoBehaviour
{
    [Header("Informations de base")]
    [SerializeField] private string objectName;
    [TextArea][SerializeField] private string description;

    [Header("Description principale")]
    [SerializeField] private TextMeshProUGUI mainTitleText;
    [SerializeField] private TextMeshProUGUI mainDescriptionText;

    public string ObjectName => objectName;
    public string Description => description;

    public virtual void OnClick()
    {
        Debug.Log($"Objet {objectName} cliqué !");

        if (mainTitleText != null)
            mainTitleText.text = ObjectName;

        if (mainDescriptionText != null)
            mainDescriptionText.text = description;
    }
}
