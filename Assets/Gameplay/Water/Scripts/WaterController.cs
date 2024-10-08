using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterController : MonoBehaviour
{
    private float _moveSpeed = 5f;
    private Rigidbody2D _rb;
    private float _jumpForce = 7f;
    [SerializeField] private LayerMask groundLayer;
    private bool _isGround = false;

    private AudioSource _audioSource;
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        _isGround = Physics2D.Raycast(transform.position, Vector2.down, 1f, groundLayer);
        Movement();
        Jump();
    }
    private void Movement()
    {
        float moveHorizontal = Input.GetAxis("Horizontal2");
        float moveVertical = 0;
        if (Input.GetKey(KeyCode.W))
        {
            moveVertical = 5f;
        }

        Vector2 movement = new Vector2(moveHorizontal * _moveSpeed, moveVertical * _moveSpeed);
        _rb.velocity = new Vector2(movement.x, _rb.velocity.y);
    }
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W) && _isGround)
        {
            _rb.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
            _audioSource.Play();
        }
    }
}
