using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float moveSpd;
    public float jumpPower;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Transform groundCheckTransform;
    [SerializeField] GameObject wandGameObject;
    private Transform characterTransform;

    [SerializeField]float attackRate = 0.6f;
    float nextAttackTime = 0f;


    private Animator anim;

    void Awake()
    {
        characterTransform = GetComponent<Transform>();
    }
    void Start()
    {

        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                anim.SetTrigger("Attack");
                nextAttackTime = Time.time + 1f/attackRate;
            }
        }     
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        
        float horizontal = Input.GetAxisRaw("Horizontal")*moveSpd;
        rb.velocity = new Vector2 (horizontal, rb.velocity.y);
        if (horizontal == 0)
        {
            anim.SetBool("isRunning", false);
        }
        else
        {
            anim.SetBool("isRunning", true);
        }

        if (horizontal > 0)
        {
            characterTransform.localScale = new Vector3(1, 1, 1);
        }
        else if (horizontal < 0)
        {
            characterTransform.localScale = new Vector3(-1, 1, 1);
        }


        //if (Input.GetKeyDown(KeyCode.Space)&& isGrounded())
        //{
        //    rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        //}
    }

    bool isGrounded()
    {
        return Physics2D.CircleCast(groundCheckTransform.transform.position, 0.1f, Vector2.down, 0.1f, groundLayer);
    }

    
}
