using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [Header("Audio source")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("Audio clip")]
    public AudioClip background;
    public AudioClip click;
    public AudioClip tampon;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
