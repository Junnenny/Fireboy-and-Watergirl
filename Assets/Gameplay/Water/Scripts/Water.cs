using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Water : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverCanvas;
    [SerializeField] private Button _restartLvl;
    [SerializeField] private Button _selectGame;
    private void Start()
    {
        _gameOverCanvas.SetActive(false);
        _restartLvl.onClick.AddListener(RestartLevel);
        _selectGame.onClick.AddListener(SelectLevel);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("FireCharacter"))
        {
            Destroy(other.gameObject);
            ShowGameOver();
        }
    }
    public void ShowGameOver()
    {
        Time.timeScale = 0;
        _gameOverCanvas.SetActive(true);
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void SelectLevel()
    {
        SceneManager.LoadScene("MainMenu");// должна быть другая сцена
    }

}
