using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{
    public float speed = 20;

    void Start()
    {
        Destroy(gameObject, 4f);
    }

    void Update()
    {
       // transform.position += transform. * speed;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Contains("TriggerForBullet"))
        {
            Destroy(gameObject);
            SceneManager.LoadScene("BossFight");
            
        }
        
    }
}
