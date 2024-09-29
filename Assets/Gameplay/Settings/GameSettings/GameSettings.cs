using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameSettings : MonoBehaviour
{
    public Slider volumeSlider;
    public TMP_Text volumeText;
    public Button exitSettingsButton;

    public GameObject settingsCanvas;
    public GameObject[] allCanvases;
    public GameObject mainCanvas;

    private void Start()
    {
        Time.timeScale = 1f;

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
        exitSettingsButton.onClick.AddListener(CloseSettings);
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
                    canvas.gameObject.SetActive(false);
                }
            }
            settingsCanvas.SetActive(true);
            FindObjectOfType<GameMenu>().SetSettingsOpen(true);
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
            FindObjectOfType<GameMenu>().SetSettingsOpen(false);
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
