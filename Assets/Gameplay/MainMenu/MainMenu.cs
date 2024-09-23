using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _settingnsButton;
    [SerializeField] private Settings _settings;

    void Start()
    {
        _playButton.onClick.AddListener(LoadNextScene);
        _settingnsButton.onClick.AddListener(OpenSettings);
    }   
    public void LoadNextScene()
    {
        SceneManager.LoadScene("1LVL");
    }
    public void OpenSettings()
    {
        if (_settings.settingsCanvas != null)
        {
            foreach (GameObject canvas in _settings.allCanvases)
            {
                if (canvas.gameObject != _settings.settingsCanvas)
                {
                    canvas.gameObject.SetActive(false);
                }
            }
            _settings.settingsCanvas.SetActive(true);
        }
        else
        {
#if UNITY_EDITOR
            Debug.LogError("Канвас настроек нулреф");
#endif
        }

    }
}
