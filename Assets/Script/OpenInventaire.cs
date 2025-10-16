using UnityEngine;
using UnityEngine.UI;

public class OpenInventaire : MonoBehaviour
{
    public static OpenInventaire Instance;
    public static bool IsInventoryOpen = false;

    [Header("Références")]
    public GameObject Inventaire;
    public Button openPanel;
    public Button closePanel;
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        openPanel.onClick.AddListener(OpenPanel);
        closePanel.onClick.AddListener(ClosePanel);

        if (Inventaire != null)
        {
            Inventaire.SetActive(false);
        }
            
    }

    public void OpenPanel()
    {
        if (Inventaire != null)
        {
            audioManager.PlaySFX(audioManager.click);
            Inventaire.SetActive(true);
            IsInventoryOpen = true;
        }
    }

    public void ClosePanel()
    {
        if (Inventaire != null)
        {
            audioManager.PlaySFX(audioManager.click);
            Inventaire.SetActive(false);
            IsInventoryOpen = false;
        }
    }
}
