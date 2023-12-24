using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    private bool isGrounded = true;
    public float speed;
    public float jumpForce;
    private float moveInput;
    private bool facingRight;

    DialogueSystem dS;
    private void Start()
    {
        Application.targetFrameRate = 60;
        rb = GetComponent<Rigidbody2D>();
        dS = GetComponent<DialogueSystem>();
    }

    private void Update()
    {
        moveInput = Input.GetAxis("Horizontal");
        if (isGrounded == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.velocity += Vector2.up * jumpForce;
                isGrounded = false;
            }
        }
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if(facingRight == false && moveInput < 0) //rotate left
        {
            Flip();
        }
        if (facingRight == true && moveInput > 0) //rotate right
        {
            Flip();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void Flip() //rotate at move
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
