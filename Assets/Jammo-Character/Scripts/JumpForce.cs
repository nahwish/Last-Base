using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpForce : MonoBehaviour
{
  // La fuerza que se aplica al saltar
    public float jumpForce = 50f;

    // Verifica si el jugador está en el suelo
    bool isGrounded = true;

    void Update()
    {
        // Si se presiona la tecla Space y el jugador está en el suelo, salta
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            // Agrega una fuerza hacia arriba para saltar
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            // Actualiza la variable "isGrounded" para indicar que el jugador no está en el suelo
            isGrounded = false;
        }
    }

    // Si el jugador toca el suelo, actualiza la variable "isGrounded" para indicar que está en el suelo
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
