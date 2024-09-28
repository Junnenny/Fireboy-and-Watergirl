using UnityEngine;

public class WaterDoor : MonoBehaviour
{
    private Animator animator;
    [HideInInspector]public bool _onDoor = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("WaterCharacter"))
        {
            animator.SetTrigger("OpenDoor");
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("WaterCharacter"))
        {
            _onDoor = true;
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("WaterCharacter"))
        {
            animator.SetTrigger("CloseDoor");
            _onDoor = false;
        }
    }
}
