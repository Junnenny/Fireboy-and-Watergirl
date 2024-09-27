using UnityEngine;

public class LeverController : MonoBehaviour
{
    public float rotationAngle = 30f;
    private bool isActivated = false;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("FireCharacter") || collision.gameObject.CompareTag("WaterCharacter"))
        {
            ToggleLever();
        }
    }

    void ToggleLever()
    {
        isActivated = true;
        float targetAngle = isActivated ? rotationAngle : -rotationAngle;
        transform.localRotation = Quaternion.Euler(0, 0, targetAngle);
    }
}

