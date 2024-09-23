using UnityEngine;

public class TakeFireCrystal : MonoBehaviour
{
    public GameCanvas gameCanvas;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("FireCharacter"))
        {
            gameCanvas.AddFireCrystal();

            Destroy(gameObject);
        }
    }
}
