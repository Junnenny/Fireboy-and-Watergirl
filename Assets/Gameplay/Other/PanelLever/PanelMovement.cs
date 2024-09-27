using UnityEngine;

public class PanelMovement : MonoBehaviour
{
    public Vector2 pointA; // ������ �����
    public Vector2 pointB; // ������ �����
    public float speed = 2f; // �������� �����������

    private Vector2 target; // ������� �����

    void Start()
    {
        // ������������� ��������� ����
        target = pointB;
    }

    void Update()
    {
        // ���������� ������ � ������� �����
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        // ���������, �������� �� �� ������� �����
        if (Vector2.Distance(transform.position, target) < 0.1f)
        {
            // ������ ���� �� ��������������� �����
            target = target == pointA ? pointB : pointA;
        }
    }
}
