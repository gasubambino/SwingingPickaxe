using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;

    void Update()
    {
        // Obtém a direção do objeto em relação ao jogador
        Vector3 directionToPlayer = player.position - transform.position;
        directionToPlayer.Normalize();

        // Calcula o ângulo em radianos
        float angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;

        // Rotaciona o objeto para o ângulo desejado
        transform.rotation = Quaternion.AngleAxis(angle+155.7f, Vector3.forward);
    }
}
