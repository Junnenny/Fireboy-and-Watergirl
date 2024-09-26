using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeWhiteCrystal : MonoBehaviour
{
    public GameCanvas gameCanvas;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("WaterCharacter") || (collision.CompareTag("FireCharacter")))
        {
            gameCanvas.AddWhiteCrystal();

            Destroy(gameObject);
        }
    }
}
