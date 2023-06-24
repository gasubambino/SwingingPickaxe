using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreScript : MonoBehaviour
{
    SpriteRenderer sprite;
    Collider2D collider;
    [SerializeField] Transform lights;
    public OreInfo oreInfo;

    private ParticleSystem destroyParticleSystem;
    private ParticleSystem hitParticleSystem;


    int oreDrop;
    int oreHp = 5;
    float respawnTime = 5;
    //gold drop
    public GameObject prefab;
    public float radius;

    //flash when hit, variables
    public Material flashMaterial;
    [SerializeField]private Material originalMaterial;
    private float flashDuration = 0.1f;


    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        collider = GetComponent<Collider2D>();
        lights = gameObject.transform.GetChild(2);
        oreDrop = oreInfo.oreDrop;

        Transform destroyP = transform.GetChild(0);
        Transform hitP = transform.GetChild(1);


        destroyParticleSystem = destroyP.GetComponent<ParticleSystem>();
        hitParticleSystem = hitP.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        oreDrop = oreInfo.oreDrop;
        if (oreHp <= 0)
        {
            OreDestroy();
        }
    }

    public void OreHit()
    {
        hitParticleSystem.Play();
        StartFlashCoroutine();
        oreHp--;
    }

    void OreDestroy()
    {
        destroyParticleSystem.Play();
        sprite.enabled = false;
        collider.enabled = false;
        lights.gameObject.SetActive(false);
        oreHp = 1;
        int spawnCount = Random.Range(oreDrop, oreDrop+oreDrop*30/100);
        for (int i = 0; i < spawnCount; i++)
        {
            // Calcular uma posição aleatória dentro do círculo com base na posição do objeto pai
            Vector2 randomOffset = Random.insideUnitCircle * radius;
            Vector2 randomPosition = (Vector2)transform.position + randomOffset;

            // Instanciar o prefab na posição aleatória
            Instantiate(prefab, randomPosition, Quaternion.identity);
        }
        StartCoroutine(Respawn());
        //Destroy(gameObject);
    }

    public void StartFlashCoroutine()
    {
        StartCoroutine(FlashCoroutine());
    }
    private IEnumerator FlashCoroutine()
    {
        GetComponent<Renderer>().material = flashMaterial;
        yield return new WaitForSeconds(flashDuration);
        GetComponent<Renderer>().material = originalMaterial;
    }

    private IEnumerator Respawn()
    {
        yield return new WaitForSeconds(respawnTime);
        lights.gameObject.SetActive(true);
        sprite.enabled = true;
        collider.enabled = true;
    }


}
