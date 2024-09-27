using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public enum ButtonState { Inactive, Active }
    public ButtonState _currentState = ButtonState.Inactive;

    private Vector3 originalPosition;
    public float pressDistance = 0.1f;
    public bool isPressed = false;

    private void Start()
    {
        originalPosition = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("WaterCharacter") && !isPressed)
        {
            isPressed = true;
            _currentState = ButtonState.Active;
            transform.position = originalPosition - new Vector3(0, pressDistance, 0);
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("WaterCharacter") && isPressed)
        {
            isPressed = false;
            _currentState = ButtonState.Inactive;
            transform.position = originalPosition;
        }
    }
}
