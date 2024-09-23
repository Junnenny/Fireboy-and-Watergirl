using UnityEngine;
using TMPro;

public class GameCanvas : MonoBehaviour
{
    public TMP_Text levelTimeText;

    private float _levelTime;

    private void Start()
    {
        _levelTime = 0f;
        UpdateLevelTimeText();
    }

    private void Update()
    {
        _levelTime += Time.deltaTime;
        UpdateLevelTimeText();
    }

    private void UpdateLevelTimeText()
    {
        float minutes = Mathf.FloorToInt(_levelTime / 60);
        float seconds = Mathf.FloorToInt(_levelTime % 60);
        levelTimeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void ResetTimer()
    {
        _levelTime = 0f;
        UpdateLevelTimeText();
    }
}
