using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    private Animator _animator;
    [SerializeField] private Button _firstLvl;
    [SerializeField] private Button _secondLvl;
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.SetTrigger("Open");
        _firstLvl.onClick.AddListener(StartFirstLevel);
        _secondLvl.onClick.AddListener(StartSecondLevel);
    }

    public void StartFirstLevel()
    {
        _animator.SetTrigger("Close");
        SceneManager.LoadScene("1LVL");
    }
    public void StartSecondLevel()
    {
        _animator.SetTrigger("Close");
        SceneManager.LoadScene("2LVL");
    }
}
