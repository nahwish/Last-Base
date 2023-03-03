using System.Collections;
using System.Collections.Generic;
using UnityEngine;


  public class recibirDanio : MonoBehaviour {

   public GameObject explosionPrefab; // Objeto de explosión que se instanciará
    [SerializeField] [Tooltip("Vida inicial del enemigo")] [Range(1,100)]
    [Header("Vida Inicial")]
    private float maxHealth = 100f;

    [Tooltip("Vida actual del enemigo")]
    [Header("Vida Actual")]
    public float currentHealth;

    void Start()
    {  
        currentHealth = maxHealth;
    }


void OnTriggerStay(Collider other)
{
    if (other.gameObject.tag == "Finish")
    {
        currentHealth -= 0.2f;
        Debug.Log("Enemy health RECIBIR PAPITOP: " + currentHealth);
        if (currentHealth <= 0)
        {
            // Crea una instancia del objeto de explosión en la posición actual del objeto
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject); // Destruye el objeto actual
        }
    }
}

}


