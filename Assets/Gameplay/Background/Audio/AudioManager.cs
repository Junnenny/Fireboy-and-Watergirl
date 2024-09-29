using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public AudioClip mainMenuMusic;
    public AudioClip levelMusic;

    private AudioSource audioSource;
    private string currentScene;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        currentScene = SceneManager.GetActiveScene().name;
        PlayMusicForCurrentScene();
    }

    void Update()
    {
        if (currentScene != SceneManager.GetActiveScene().name)
        {
            currentScene = SceneManager.GetActiveScene().name;
            PlayMusicForCurrentScene();
        }

        if (!audioSource.isPlaying)
        {
            PlayCurrentMusic();
        }
    }

    private void PlayMusicForCurrentScene()
    {
        string sceneName = SceneManager.GetActiveScene().name;

        switch (sceneName)
        {
            case "MainMenu":
                if (audioSource.clip != mainMenuMusic)
                {
                    audioSource.clip = mainMenuMusic;
                    PlayCurrentMusic();
                }
                break;
            case "LVLs":
                if (audioSource.clip != mainMenuMusic)
                {
                    audioSource.clip = mainMenuMusic;
                    PlayCurrentMusic();
                }
                break;
            case "1LVL":
            case "2LVL":
                if (audioSource.clip != levelMusic)
                {
                    audioSource.clip = levelMusic;
                    PlayCurrentMusic();
                }
                break;
            case "EndGame":
                if (audioSource.clip != mainMenuMusic)
                {
                    audioSource.clip = mainMenuMusic;
                    PlayCurrentMusic();
                }
                break;
            default:
                break;
        }
    }

    private void PlayCurrentMusic()
    {
        audioSource.Play();
    }
}
