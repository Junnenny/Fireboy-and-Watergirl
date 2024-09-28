using UnityEngine;

public class FireDoor : MonoBehaviour
{
    private Animator animator;
    public bool _onDoor = false;

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
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("FireCharacter"))
        {
            _onDoor = true;
            Debug.Log("фаер стоит");
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("FireCharacter"))
        {
            animator.SetBool("OpenDoor", false);
            animator.SetTrigger("CloseDoor");
            _onDoor= false;
        }
    }
}

