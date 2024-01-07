using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    private bool isGrounded = true;
    public float speed;
    public float jumpForce;
    private float moveInput;
    private bool facingRight;
    public string thisScene;
    public GameObject fade;
    public Animator animator;
    DialogueSystem dS;
    public AudioSource source;
    public AudioClip jumpSound;

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
                source.PlayOneShot(jumpSound);
                //animator.Play("jump");
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
            jumpForce = 5;
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            jumpForce = 6.5f;
            isGrounded = true;
        }
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Invoke("SceneLoad", 1f);
            fade.SetActive(true);
            speed = 0;
            jumpForce = 0;
        }
    }

    void Flip() //rotate at move
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
    void SceneLoad()
    {
        SceneManager.LoadScene(thisScene);
    }
}
