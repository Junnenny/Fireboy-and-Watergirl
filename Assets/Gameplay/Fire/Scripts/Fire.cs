using UnityEngine;

public class Fire : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("WaterCharacter"))
        {
            Destroy(other.gameObject);
        }
    }
}
