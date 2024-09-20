using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] musicClips;
    private AudioSource audioSource;
    private int currentClipIndex = 0;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
        PlayNextClip();
    }

    void PlayNextClip()
    {
        if (musicClips.Length == 0) return;

        audioSource.clip = musicClips[currentClipIndex];
        audioSource.Play();
        currentClipIndex = (currentClipIndex + 1) % musicClips.Length;
        Invoke("PlayNextClip", audioSource.clip.length);
    }
}
