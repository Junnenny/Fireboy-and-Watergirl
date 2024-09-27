using UnityEngine;

public class PanelButtonController : MonoBehaviour
{
    [SerializeField] private ButtonController _buttonController;

    public Transform panel;
    public Vector2 targetPosition;
    public float moveSpeed = 5f;

    private Vector2 originalPosition;

    void Start()
    {
        originalPosition = panel.position;
    }

    void Update()
    {
        if (_buttonController._currentState == ButtonController.ButtonState.Active)
        {
            panel.position = Vector3.MoveTowards(panel.position, targetPosition, moveSpeed * Time.deltaTime);
        }
        else
        {
            panel.position = Vector3.MoveTowards(panel.position, originalPosition, moveSpeed * Time.deltaTime);
        }
    }
}

