using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    private Vector3 originalPosition;
    public float pressDistance = 0.1f; // Расстояние, на которое кнопка будет "нажиматься"
    private bool isPressed = false; // Состояние кнопки

    private void Start()
    {
        originalPosition = transform.position; // Сохраняем оригинальную позицию кнопки
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("WaterCharacter") && !isPressed)
        {
            isPressed = true; // Устанавливаем состояние нажатия
            PressButton();
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("WaterCharacter") && isPressed)
        {
            isPressed = false; // Сбрасываем состояние нажатия
            ReleaseButton();
        }
    }

    private void PressButton()
    {
        transform.position = originalPosition - new Vector3(0, pressDistance, 0); // Устанавливаем кнопку в нажатое положение
    }

    private void ReleaseButton()
    {
        transform.position = originalPosition; // Возвращаем кнопку в оригинальное положение
    }
}
