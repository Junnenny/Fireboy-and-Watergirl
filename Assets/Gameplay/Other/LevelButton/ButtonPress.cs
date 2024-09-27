using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    private Vector3 originalPosition;
    public float pressDistance = 0.1f; // ����������, �� ������� ������ ����� "����������"
    private bool isPressed = false; // ��������� ������

    private void Start()
    {
        originalPosition = transform.position; // ��������� ������������ ������� ������
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("WaterCharacter") && !isPressed)
        {
            isPressed = true; // ������������� ��������� �������
            PressButton();
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("WaterCharacter") && isPressed)
        {
            isPressed = false; // ���������� ��������� �������
            ReleaseButton();
        }
    }

    private void PressButton()
    {
        transform.position = originalPosition - new Vector3(0, pressDistance, 0); // ������������� ������ � ������� ���������
    }

    private void ReleaseButton()
    {
        transform.position = originalPosition; // ���������� ������ � ������������ ���������
    }
}
