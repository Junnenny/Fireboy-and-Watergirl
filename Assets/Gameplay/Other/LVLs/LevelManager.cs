using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Button _firstLvl;
    [SerializeField] private Button _secondLvl;
    private void Start()
    {
        _firstLvl.onClick.AddListener(StartFirstLevel);
        _secondLvl.onClick.AddListener(StartSecondLevel);
    }

    public void StartFirstLevel()
    {
        SceneManager.LoadScene("1LVL");
    }
    public void StartSecondLevel()
    {
        SceneManager.LoadScene("2LVL");
    }
}
