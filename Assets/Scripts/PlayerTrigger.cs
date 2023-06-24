using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    public GameObject sparkle;
    public int goldCount;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Drop"))
        {
            goldCount++;
            Instantiate(sparkle, collision.gameObject.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);   
        }
    }
}
