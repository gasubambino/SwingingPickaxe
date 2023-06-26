using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldDrop : MonoBehaviour
{
    [SerializeField] Sprite[] sprites;

    public float impulseForce = 5f;
    public float lateralForce = 2f;

    private Rigidbody2D rb;

    private Transform target;
    public float initialSpeed = 6.0f; // Initial speed
    public float acceleration = 6.0f; // Acceleration rate

    public GameObject playerPos;
    private bool magnetActive = false;
    Vector3 targetPos;

    void Start()
    {
        playerPos = GameObject.FindWithTag("Player");
        //RANDOM SPRITE BETWEEN 5
        int randomIndex = Random.Range(0, sprites.Length);
        SpriteRenderer spriteRenderer = gameObject.GetComponentInChildren<SpriteRenderer>();
        spriteRenderer.sprite = sprites[randomIndex];

        rb = GetComponent<Rigidbody2D>();
        ApplyImpulse();
    }

    private void ApplyImpulse()
    {
        // Aplica um impulso para cima
        Vector2 impulse = Vector2.up * impulseForce;

        // Aplica um impulso aleatório para um lado
        impulse += Vector2.right * Random.Range(-lateralForce, lateralForce);

        // Aplica o impulso ao Rigidbody2D
        rb.AddForce(impulse, ForceMode2D.Impulse);

        StartCoroutine(Timer());
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (magnetActive == true)
        {
            targetPos = playerPos.transform.position;
            Vector2 targetDir = (targetPos - transform.position).normalized;
            rb.velocity = new Vector2(targetDir.x, targetDir.y)*12.6f;
        }    
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(1.5f);
        Rigidbody2D myRigidbody = GetComponent<Rigidbody2D>();
        myRigidbody.gravityScale = 0f;
        Collider2D myCollider = GetComponent<Collider2D>();
        myCollider.isTrigger = true;
        magnetActive = true;
    }
}
