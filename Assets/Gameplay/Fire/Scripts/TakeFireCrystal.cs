using UnityEngine;

public class TakeFireCrystal : MonoBehaviour
{
    public GameCanvas gameCanvas;
    private AudioSource _audioSource;
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("FireCharacter"))
        {
            _audioSource.Play();
            gameCanvas.AddFireCrystal();
            Destroy(gameObject);
        }
    }
}
