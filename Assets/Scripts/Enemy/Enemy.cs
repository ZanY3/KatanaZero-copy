using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    private Transform player;
    public int health;
    public AudioSource source;
    public AudioClip dieClip;
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
        if(collision.gameObject.CompareTag("Pickble"))
        {
            TakeDamage(1);
        }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
    }

}
