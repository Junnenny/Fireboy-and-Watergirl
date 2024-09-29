using UnityEngine;

public class WaterDoor : MonoBehaviour
{
    private Animator animator;
    [HideInInspector]public bool _onDoor = false;

    private AudioSource _audioSource;

    void Start()
    {
        animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("WaterCharacter"))
        {
            animator.SetTrigger("OpenDoor");
            _audioSource.Play();
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
            _audioSource.Stop();
            _audioSource.Play();
        }
    }
}
