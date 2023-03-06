using System.Collections;
using System.Collections.Generic;
using UnityEngine;


  public class recibirDanio : MonoBehaviour {

    public GameObject animation1; // Objeto de explosión que se instanciará
    public GameObject animation2; // Objeto de explosión que se instanciará
    public enum options {none,uno}
    public enum ObjectInsideOptions { None, Objects }
    public ObjectInsideOptions objectInsideOption;
    public GameObject objectInside; // Objeto de explosión que se instanciará
    
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
        if (other.gameObject.tag == "Spray")
        {
            currentHealth -= 0.2f;
            Debug.Log("Enemy health RECIBIR PAPITOP: " + currentHealth);
            if (currentHealth <= 0)
            {
                // Crea una instancia del objeto de explosión en la posición actual del objeto
                Instantiate(animation1, transform.position, Quaternion.identity);
                Instantiate(animation2, transform.position, Quaternion.identity);

                if (objectInsideOption == ObjectInsideOptions.Objects)
                {
                    Instantiate(objectInside, transform.position, transform.rotation);
                }
                // No se instancia ningún objeto si la opción es "None"

                Destroy(gameObject); // Destruye el objeto actual
            }
        }
    }

    

    void OnCollisionEnter(Collision collision)
{
    if (collision.gameObject.tag == "Spray")
    {
        currentHealth -= 0.2f;
        Debug.Log("Enemy health RECIBIR PAPITOP: " + currentHealth);
        if (currentHealth <= 0)
        {
            // Crea una instancia del objeto de explosión en la posición actual del objeto
            Instantiate(animation1, transform.position, Quaternion.identity);
            Instantiate(animation2, transform.position, Quaternion.identity);

            if (objectInsideOption == ObjectInsideOptions.Objects)
            {
                Instantiate(objectInside, transform.position, transform.rotation);
            }
            // No se instancia ningún objeto si la opción es "None"

            Destroy(gameObject); // Destruye el objeto actual
        }
    }

}

  }

