using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sparkle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float randomAngle = Random.Range(0, 360);
        transform.rotation = Quaternion.Euler(0f, 0f, randomAngle);
        Destroy(gameObject,0.3f);
    }
}
