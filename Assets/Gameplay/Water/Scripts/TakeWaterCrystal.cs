using UnityEngine;

public class TakeWaterCrystal : MonoBehaviour
{
    public GameCanvas gameCanvas;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("WaterCharacter"))
        {
            gameCanvas.AddWaterCrystal();
            Destroy(gameObject);
        }
    }
}

