using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{

    public GameObject sparkle;

    private void Awake()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
            if(collision.gameObject.CompareTag("goldDrop"))
            {
                Instantiate(sparkle, collision.gameObject.transform.position, Quaternion.identity);
                Destroy(collision.gameObject);
                GoldDropAction();
            }
            else if (collision.gameObject.CompareTag("pinkDrop"))
            {
                Instantiate(sparkle, collision.gameObject.transform.position, Quaternion.identity);
                Destroy(collision.gameObject);
                PinkDropAction();
            }
    }

    private void GoldDropAction()
    {
        GameManager.Instance.playerGoldCount++;
    }

    private void PinkDropAction()
    {
        GameManager.Instance.playerPinkCount++;
    }
}
