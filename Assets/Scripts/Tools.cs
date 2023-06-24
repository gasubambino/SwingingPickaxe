using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tools : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    public bool goingDown = false;

    public float forceMagnitude = 5;
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (goingDown)
        {
            boxCollider.enabled = true;
        }
        else { boxCollider.enabled = false; }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (goingDown)
        {
            if (collision.gameObject.CompareTag("ore"))
            {               
                collision.gameObject.GetComponent<OreScript>().OreHit();
            }
            if (collision.gameObject.CompareTag("slime"))
            {
                Vector3 direction = transform.position - collision.transform.position;
                direction.y = 0f;
                direction.x *= -1;
                direction.Normalize();
                collision.gameObject.GetComponent<SlimeWalk>().slimeRb.velocity = Vector3.zero;
                collision.gameObject.GetComponent<SlimeWalk>().TakeDamage();
                collision.gameObject.GetComponent<SlimeWalk>().knockBack = true;
                collision.gameObject.GetComponent<SlimeWalk>().StartKnockBackTimer();
                collision.gameObject.GetComponent<SlimeWalk>().KnockBack(direction, forceMagnitude);
            }
        }
        
    }
}
