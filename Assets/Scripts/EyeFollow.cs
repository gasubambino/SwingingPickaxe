using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;

    void Update()
    {
        // Obt�m a dire��o do objeto em rela��o ao jogador
        Vector3 directionToPlayer = player.position - transform.position;
        directionToPlayer.Normalize();

        // Calcula o �ngulo em radianos
        float angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;

        // Rotaciona o objeto para o �ngulo desejado
        transform.rotation = Quaternion.AngleAxis(angle+155.7f, Vector3.forward);
    }
}
