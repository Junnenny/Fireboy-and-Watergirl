using UnityEngine;
using TMPro;
using System;

public class GameCanvas : MonoBehaviour
{
    public TMP_Text levelTimeText;
    public TMP_Text fireCrystalText;
    public TMP_Text waterCrystalText;


    private float _levelTime;
    private int _fireCrystalQuantity;
    private int _waterCrystalQuantity;


    private void Start()
    {
        _levelTime = 0f;
        _fireCrystalQuantity = 0;
        _waterCrystalQuantity = 0;
        UpdateText();
    }

    private void Update()
    {
        _levelTime += Time.deltaTime;
        UpdateText();
    }

    private void UpdateText()
    {
        float minutes = Mathf.FloorToInt(_levelTime / 60);
        float seconds = Mathf.FloorToInt(_levelTime % 60);
        levelTimeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void ResetTimer()
    {
        _levelTime = 0f;
        UpdateText();
    }
    public void AddFireCrystal()
    {
        _fireCrystalQuantity++;
        UpdateFireCrystalCountText();
    }
    public void AddWaterCrystal()
    {
        _waterCrystalQuantity++;
        UpdateWaterCrystalCountText();
    }

    private void UpdateFireCrystalCountText()
    {
        fireCrystalText.text = Convert.ToString(_fireCrystalQuantity);
    }
    private void UpdateWaterCrystalCountText()
    {
        waterCrystalText.text = Convert.ToString(_waterCrystalQuantity);
    }
}
