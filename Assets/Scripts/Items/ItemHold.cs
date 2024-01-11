using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHold : MonoBehaviour
{
    public bool hold;
    public float distance;
    RaycastHit2D hit;
    public Transform holdPoint;
    public float throwItem;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(!hold)
            {
                Physics2D.queriesStartInColliders = false; //to ignore people colider
                hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance); //to find items

                if(hit.collider != null && hit.collider.tag == "Pickble")
                {
                    hold = true;
                }
            }
            else
            {
                hold = false;

                if(hit.collider.gameObject.GetComponent<Rigidbody2D>() != null)
                {
                    hit.collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x, 1) * throwItem; //throwss
                }
            }
        }

        if(hold)
        {
            hit.collider.gameObject.transform.position = holdPoint.position; //transform item to player arms
        }
    }
    private void OnDrawGizmos() //for clarity of the item pick zone
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.right * transform.localScale.x * distance);
    }
}
