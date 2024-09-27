using UnityEngine;

public class PanelController : MonoBehaviour
{
    [SerializeField] private LeverController _leverController;
    public Transform panel;
    public Vector2 targetPosition;
    public float moveSpeed = 5f;

    public Vector2 originalPosition;
    private bool isMoving = false;

    void Start()
    {
        originalPosition = panel.position;
    }

    void Update()
    {
        if (_leverController._currentState == LeverController.LeverState.Inactive)
        {
            isMoving = !isMoving;
        }

        if (isMoving)
        {
            panel.position = Vector3.MoveTowards(panel.position, targetPosition, moveSpeed * Time.deltaTime);
            if (Vector2.Distance(panel.position, targetPosition) < 0.01f)
            {
                isMoving = false;
            }
        }
        else
        {
            panel.position = Vector3.MoveTowards(panel.position, originalPosition, moveSpeed * Time.deltaTime);
            if (Vector2.Distance(panel.position, originalPosition) < 0.01f)
            {
                isMoving = true;
            }
        }
    }
}
