using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    private Animator _animator;
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _settingnsButton;
    [SerializeField] private Settings _settings;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _playButton.onClick.AddListener(LoadNextScene);
        _settingnsButton.onClick.AddListener(OpenSettings);
    }   
    public void LoadNextScene()
    {
        SceneManager.LoadScene("LVLs");
    }
    public void OpenSettings()
    {
        if (_settings.settingsCanvas != null)
        {
            foreach (GameObject canvas in _settings.allCanvases)
            {
                if (canvas.gameObject != _settings.settingsCanvas)
                {
                    _animator.SetTrigger("Close");
                    canvas.gameObject.SetActive(false);
                }
            }
            _settings.settingsCanvas.SetActive(true);
            _animator.SetTrigger("Open");

        }
        else
        {
#if UNITY_EDITOR
            Debug.LogError("Канвас настроек нулреф");
#endif
        }

    }
}
