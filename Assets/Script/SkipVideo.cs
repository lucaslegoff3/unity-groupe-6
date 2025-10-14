using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneAutoLoader : MonoBehaviour
{
    public float autoLoadDelay;
    private float timer;

    private void Start()
    {
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LoadNextScene();
        }

        timer = 0f;
        autoLoadDelay = 60f;

        timer += Time.deltaTime;
        if (timer >= autoLoadDelay)
        {
            LoadNextScene();
        }
    }

    private void LoadNextScene()
    {
        enabled = false;

        Debug.Log($"Chargement de la scène : Game");
        SceneManager.LoadScene("Game");
    }
}
