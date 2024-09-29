using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Settings : MonoBehaviour
{
    private Animator _animator;
    public Slider volumeSlider;
    public TMP_Text volumeText;
    public Button exitGameButton;
    public Button exitSettingsButton;

    public GameObject settingsCanvas;
    public GameObject[] allCanvases;
    public GameObject mainCanvas;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        if (settingsCanvas != null)
        {
            settingsCanvas.SetActive(false);
        }
        else
        {
#if UNITY_EDITOR
            Debug.LogError("канвас настроек нулреф");
#endif
        }

        float volume = PlayerPrefs.GetFloat("Volume", 1f);
        volumeSlider.value = volume;
        AudioListener.volume = volume;
        UpdateVolumeText(volume);

        volumeSlider.onValueChanged.AddListener(SetVolume);
        if (exitGameButton != null)
        {
            exitGameButton.onClick.AddListener(QuitGame);
        }
        exitSettingsButton.onClick.AddListener(CloseSettings);
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (settingsCanvas.activeSelf)
            {
                CloseSettings();
            }
            else
            {
                OpenSettings();
            }
        }
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
        PlayerPrefs.SetFloat("Volume", volume);
        UpdateVolumeText(volume);
    }

    private void UpdateVolumeText(float volume)
    {
        volumeText.text = "Громкость: " + (volume * 100).ToString("F0") + "%";
    }
    public void OpenSettings()
    {
        if (settingsCanvas != null)
        {
            foreach (GameObject canvas in allCanvases)
            {
                if (canvas.gameObject != settingsCanvas)
                {
                    _animator.SetTrigger("Close");
                    canvas.gameObject.SetActive(false);

                }
            }
            settingsCanvas.SetActive(true);
            _animator.SetTrigger("Open");
        }
        else
        {
#if UNITY_EDITOR
            Debug.LogError("Канвас настроек нулреф");
#endif
        }

    }
    public void CloseSettings()
    {
        if (settingsCanvas != null)
        {
            settingsCanvas.SetActive(false);
            if (mainCanvas != null)
            {
                mainCanvas.SetActive(true);
            }
        }
        else
        {
#if UNITY_EDITOR
            Debug.LogError("Канвас настроек нулреф");
#endif
        }

    }
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}
