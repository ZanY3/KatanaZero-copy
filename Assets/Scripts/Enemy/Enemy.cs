using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    private Transform player;
    public int health;
    public AudioSource source;
    public AudioClip dieClip;
    ItemHold itemHold;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        if(health <= 0)
        {
            source.PlayOneShot(dieClip);
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Wall"))
        {
            if(speed > 0)
            {
                speed = - speed;
            }

        }
        if(collision.gameObject.CompareTag("LeftWallForEnemy"))
        {
            if (speed < 0)
            {
                speed = 3;
            }

        }
        if (collision.gameObject.CompareTag("Pickble"))
        {
            TakeDamage(1);
        }
    
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
    }

}
