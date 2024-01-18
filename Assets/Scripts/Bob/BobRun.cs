using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobRun : MonoBehaviour
{
    public int speed;
    Rigidbody2D rb;
    public Transform runPoint;

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, runPoint.position, speed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name.Contains("Teleporter"))
        {
            Destroy(gameObject);
        }
    }
}
