using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour {
     public GameObject animationPrefab;  // El prefab de la animación que quieres instanciar

    private void OnTriggerEnter(Collider other)
    {
            Debug.Log("holis");
        if (other.CompareTag("Player"))  // Comprueba si el jugador ha entrado en el área
        {
            Instantiate(animationPrefab, transform.position, Quaternion.identity);  // Instancia la animación en la posición del objeto actual
        }
    }
}

