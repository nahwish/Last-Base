using System.Collections;
using System.Collections.Generic;
using UnityEngine;


  public class recibirDanio : MonoBehaviour {
    public float maxHealth = 100f;
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
                Destroy(gameObject);
            }
        }
    }
}


