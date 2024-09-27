using UnityEngine;

public class FireDoor : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("FireCharacter"))
        {
            animator.SetTrigger("OpenDoor");
            animator.SetBool("OpenDoor", true);

        }
    }
  

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("FireCharacter"))
        {
            animator.SetBool("OpenDoor", false);
            animator.SetTrigger("CloseDoor");
        }
    }
}

