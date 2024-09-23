using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    public GameObject gameMenuCanvas;
    public GameObject pauseMenuUI;
    public Button continueGame;
    public Button restartButton;
    public Button selectLevelButton;
    public Button settingsButton;
    public Button exitButton;

    private bool isPaused = false;

    public GameSettings gameSettings;

    private void Start()
    {
        if (gameMenuCanvas != null)
        {
            gameMenuCanvas.SetActive(false);
        }
        else
        {
#if UNITY_EDITOR
            Debug.LogError("канвас настроек нулреф");
#endif
        }
        pauseMenuUI.SetActive(false);

        continueGame.onClick.AddListener(ContinueGame);
        restartButton.onClick.AddListener(RestartLevel);
        selectLevelButton.onClick.AddListener(SelectLevel);
        settingsButton.onClick.AddListener(OpenSettings);
        exitButton.onClick.AddListener(ExitGame);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        gameMenuCanvas.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    private void Pause()
    {
        pauseMenuUI.SetActive(true);
        gameMenuCanvas.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
    private void ContinueGame()
    {
        pauseMenuUI.SetActive(false);
        gameMenuCanvas.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }


    private void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void SelectLevel()
    {
        Debug.Log("Выбор уровня"); // добавить ссылку на сцену с уровнями
    }

    private void OpenSettings()
    {
        gameSettings.OpenSettings();
    }

    private void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}
