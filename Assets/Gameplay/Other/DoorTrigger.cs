using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private FireDoor _fireDoor;
    [SerializeField] private WaterDoor _waterDoor;

    [SerializeField] private GameObject _compliteGameCanvas;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _nextLevelButton;
    [SerializeField] private Button _chooseLevelButton;
    [SerializeField] private Button _enterMenu;
    private void Start()
    {
        _compliteGameCanvas.SetActive(false);
        _restartButton.onClick.AddListener(RestartLevel);
        _chooseLevelButton.onClick.AddListener(SelectLevel);
        _nextLevelButton.onClick.AddListener(StartNextLevel);
        _enterMenu.onClick.AddListener(EnterMenu);
    }

    private void Update()
    {
        if(_fireDoor._onDoor && _waterDoor._onDoor)
        {
            _compliteGameCanvas.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    private void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void SelectLevel()
    {
        SceneManager.LoadScene("LVLs");
    }
    private void StartNextLevel()
    {
        Time.timeScale = 1f;
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex + 1);
    }
    private void EnterMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
