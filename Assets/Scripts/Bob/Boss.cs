using UnityEngine;

public class Boss : MonoBehaviour
{
    public float speed;
    public Transform walkPoint;
    public GameObject bullet;
    public Transform shootPoint;
    public float health;
    public AudioSource source;
    public AudioClip dieClip;
    public GameObject flash;
    public GameObject teleporter;

    private float timer;

    private void Update()
    {
        if(health <= 0)
        {
            teleporter.SetActive(true);
            source.PlayOneShot(dieClip);
            Destroy(gameObject);
        }
        timer += Time.deltaTime;
        if(timer > 1.5f)
        {
            timer = 0;
            Shoot();
        }
        transform.position = Vector2.MoveTowards(transform.position, walkPoint.position, speed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            if (speed > 0)
            {
                speed = -speed;
            }

        }
        if (collision.gameObject.CompareTag("LeftWallForEnemy"))
        {
            if (speed < 0)
            {
                speed = 3;
            }

        }

    }
    public void Shoot()
    {
        Instantiate(bullet, shootPoint.position, Quaternion.identity) ;
    }
    public void TakeDamage(int damage)
    {
        flash.SetActive(true);
        health -= damage;
    }
}
