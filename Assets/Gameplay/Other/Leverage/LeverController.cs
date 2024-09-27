using UnityEngine;

public class LeverController : MonoBehaviour
{
    private enum LeverState { Inactive, Active }
    private LeverState currentState = LeverState.Inactive;

    public float activeRotationAngle = 45f;
    public float inactiveRotationAngle = -45f;
    public float rotationSpeed = 5f;
    public float forceThreshold = 1f; // Порог силы для переключения состояния

    [SerializeField] private Transform pivot;


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody2D>() != null)
        {
            Vector2 force = collision.relativeVelocity * collision.rigidbody.mass;

            if (force.magnitude > forceThreshold)
            {
                ToggleLever();
            }
        }
    }

    private void ToggleLever()
    {
        currentState = currentState == LeverState.Inactive ? LeverState.Active : LeverState.Inactive;
        PerformActionBasedOnState();
    }

    private void Update()
    {
        float targetAngle = currentState == LeverState.Active ? activeRotationAngle : inactiveRotationAngle;
        float angle = Mathf.LerpAngle(pivot.eulerAngles.z, targetAngle, Time.deltaTime * rotationSpeed);
        pivot.eulerAngles = new Vector3(0, 0, angle);
    }

    private void PerformActionBasedOnState()
    {
        Debug.Log("Lever is now " + (currentState == LeverState.Active ? "Active" : "Inactive"));
    }
}
    
