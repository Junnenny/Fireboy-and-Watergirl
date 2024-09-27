using UnityEngine;

public class PanelMovement : MonoBehaviour
{
    public Vector2 pointA; // Первая точка
    public Vector2 pointB; // Вторая точка
    public float speed = 2f; // Скорость перемещения

    private Vector2 target; // Целевая точка

    void Start()
    {
        // Устанавливаем начальную цель
        target = pointB;
    }

    void Update()
    {
        // Перемещаем объект к целевой точке
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        // Проверяем, достигли ли мы целевой точки
        if (Vector2.Distance(transform.position, target) < 0.1f)
        {
            // Меняем цель на противоположную точку
            target = target == pointA ? pointB : pointA;
        }
    }
}
