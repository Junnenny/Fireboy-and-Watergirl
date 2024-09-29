using System.Collections;
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
        Time.timeScale = 1f;

        _animator = GetComponent<Animator>();
        _animator.SetTrigger("Open");
        _firstLvl.onClick.AddListener(() => StartCoroutine(StartLevel("1LVL")));
        _secondLvl.onClick.AddListener(() => StartCoroutine(StartLevel("2LVL")));
    }

    private IEnumerator StartLevel(string levelName)
    {
        _animator.SetTrigger("Close");

        yield return new WaitForSeconds(_animator.GetCurrentAnimatorStateInfo(0).length);

        SceneManager.LoadScene(levelName);
    }
}
