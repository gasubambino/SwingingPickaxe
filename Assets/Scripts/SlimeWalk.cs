using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class SlimeWalk : MonoBehaviour
{
    float slimeHp = 5;
    public float moveSpeed = 2f;
    public float minDistance = 1f;
    public float maxDistance = 3f;
    float stopTimer;
    public Rigidbody2D slimeRb;
    private int moveDirection;

    private Animator animator;

    //flash when hit, variables
    public Material flashMaterial;
    [SerializeField] private Material originalMaterial;
    private float flashDuration = 0.1f;

    public bool knockBack = false;

    [SerializeField] GameObject destroyParticleSystem;
    [SerializeField] GameObject hitParticleSystem;
    //private ParticleSystem destroyParticleSystem;
    //private ParticleSystem hitParticleSystem;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        slimeRb = GetComponent<Rigidbody2D>();
        StartCoroutine(RandomMovement());
    }

    private void Update()
    {
        if (slimeHp <= 0)
        {
            SlimeDestroy();
        }
    }

    private IEnumerator RandomMovement()
    {
        
            float inicialTime = Time.time;
            moveDirection = Random.Range(0, 2) == 0 ? -1 : 1;
            if (moveDirection == 1)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (moveDirection == -1)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            moveSpeed = Random.Range(1, 2);

            stopTimer = Random.Range(1, 5);
            while (Time.time - inicialTime < stopTimer)
            {
                if (knockBack == false)
                {
                    Move(moveDirection, moveSpeed);
                }                
                yield return null;
            }
            slimeRb.velocity = Vector3.zero;
            animator.SetBool("isWalking", false);
        yield return new WaitForSeconds(3);
        StartCoroutine(RandomMovement());    
    }

    private void Move(int moveDirection, float moveSpeed)
    {
        animator.SetBool("isWalking", true);
        Vector3 movement = new Vector3(moveDirection * moveSpeed, slimeRb.velocity.y);
        slimeRb.velocity = movement;
    }

    public void TakeDamage()
    {
        Instantiate(hitParticleSystem,transform.position, Quaternion.identity);
        StartCoroutine(FlashCoroutine());
        slimeHp--;
    }

    public void SlimeDestroy()
    {
        Instantiate(destroyParticleSystem, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private IEnumerator FlashCoroutine()
    {
        GetComponentInChildren<Renderer>().material = flashMaterial;
        yield return new WaitForSeconds(flashDuration);
        GetComponentInChildren<Renderer>().material = originalMaterial;
    }

    public void StartKnockBackTimer()
    {
        StartCoroutine(KnockBackTimer());
    }

    private IEnumerator KnockBackTimer()
    {
        yield return new WaitForSeconds(1);
        knockBack = false;
    }

    public void KnockBack(Vector3 direction, float forceMagnitude)
    {


        slimeRb.AddForce(direction * forceMagnitude, ForceMode2D.Impulse);
    }

    

}