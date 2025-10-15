using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneAutoLoader : MonoBehaviour
{
    [Header("Configuration")]

    [Tooltip("Temps avant de charger automatiquement la sc�ne (en secondes).")]
    public float autoLoadDelay = 60f;

    private float timer = 0f;
    private bool hasLoaded = false;

    private void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            LoadNextScene();
        }

        if (timer >= autoLoadDelay && !hasLoaded)
        {
            LoadNextScene();
        }
    }

    private void LoadNextScene()
    {
        if (hasLoaded) return;
        hasLoaded = true;

        Debug.Log(" Chargement de la sc�ne : Game");
        SceneManager.LoadScene("Game");
    }
}
