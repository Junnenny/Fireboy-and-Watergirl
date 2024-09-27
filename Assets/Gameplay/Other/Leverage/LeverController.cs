using UnityEngine;

public class LeverController : MonoBehaviour
{
    public enum LeverState { Inactive, Active }
    public LeverState _currentState = LeverState.Inactive;

    public float activeRotationAngle = 45f;
    public float inactiveRotationAngle = -45f;
    public float rotationSpeed = 5f;
    public float forceThreshold = 1f;

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
        _currentState = _currentState == LeverState.Inactive ? LeverState.Active : LeverState.Inactive;
    }

    private void Update()
    {
        float targetAngle = _currentState == LeverState.Active ? activeRotationAngle : inactiveRotationAngle;
        float angle = Mathf.LerpAngle(pivot.eulerAngles.z, targetAngle, Time.deltaTime * rotationSpeed);
        pivot.eulerAngles = new Vector3(0, 0, angle);
    }
}
    
