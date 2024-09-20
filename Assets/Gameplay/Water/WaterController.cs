using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterController : MonoBehaviour
{
    private float _moveSpeed = 5f;
    private Rigidbody2D _rb;
    private float _jumpForce = 10f;
    private bool _isGround = false;
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
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
            _isGround = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGround = true;
        }
    }
}
