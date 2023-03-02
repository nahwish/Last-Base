using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaidaPersonaje : MonoBehaviour {
    private Rigidbody rb;

    private void Start() {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Suelo")) {
            // Restablecer todas las restricciones de movimiento
            rb.constraints = RigidbodyConstraints.None;
            // Establecer la restricción en Z
            rb.constraints |= RigidbodyConstraints.FreezePositionZ;
            // Desactivar temporalmente la propiedad isKinematic
            rb.isKinematic = false;

            // Rotar el objeto para que siempre esté orientado hacia abajo
            Vector3 normal = collision.contacts[0].normal;
            Quaternion rotation = Quaternion.FromToRotation(transform.up, normal) * transform.rotation;
            transform.rotation = rotation;
        }
    }
}




