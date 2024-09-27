using UnityEngine;

public class WaterDoor : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("WaterCharacter"))
        {
            animator.SetTrigger("OpenDoor");
            animator.SetBool("OpenDoor", true);

        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("WaterCharacter"))
        {
            animator.SetBool("OpenDoor", false);
            animator.SetTrigger("CloseDoor");
        }
    }
}
