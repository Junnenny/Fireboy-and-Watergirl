using UnityEngine;

public class WaterDoor : MonoBehaviour
{
    private Animator animator;
    public bool _onDoor = false;

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
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("WaterCharacter"))
        {
            _onDoor = true;
            Debug.Log("вотер стоит");
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("WaterCharacter"))
        {
            animator.SetBool("OpenDoor", false);
            animator.SetTrigger("CloseDoor");
            _onDoor = false;
        }
    }
}
