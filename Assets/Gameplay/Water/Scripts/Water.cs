using UnityEngine;

public class Water : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("FireCharacter"))
        {
            Destroy(other.gameObject);
        }
    }
}
