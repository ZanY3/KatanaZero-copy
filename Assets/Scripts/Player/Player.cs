using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    private bool isGrounded = true;
    public float speed;
    public float jumpForce;
    private float moveInput;
    public bool facingRight = true;
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
        if(facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0) 
        {   
            Flip();
        }
        
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

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            jumpForce = 5;
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
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
    
    void SceneLoad()
    {
        SceneManager.LoadScene(thisScene);
    }
}
