using UnityEngine;
using UnityEngine.SceneManagement;

public class videoVictory : MonoBehaviour
{
    [Header("Configuration")]

    [Tooltip("Temps avant de charger automatiquement la scène (en secondes).")]
    public float autoLoadDelay = 12f;

    private float timer = 0f;
    private bool hasLoaded = false;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= autoLoadDelay && !hasLoaded)
        {
            LoadNextScene();
        }
    }

    private void LoadNextScene()
    {
        if (hasLoaded) return;
        hasLoaded = true;

        Debug.Log(" Chargement de la scène : Intro");
        SceneManager.LoadScene("Intro");
    }
}
