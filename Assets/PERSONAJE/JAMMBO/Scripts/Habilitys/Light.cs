using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Prefab a instanciar")]
    private GameObject lightsPrefab;
    [SerializeField]
    [Tooltip("Prefab Speed")]
    private GameObject lightSpeed;
    private GameObject lightsInstance; // variable para almacenar la instancia de las luces
    private bool isActive = false;
    private Vector3 previousPosition;

    private const float MIN_MOVE_DISTANCE = 0.01f;

    void Update()
    {
        SpotLight();
    }

    void SpotLight()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            if (isActive)
            {
                // Si las luces ya están activas, las apaga destruyendo la instancia
                Destroy(lightsInstance);
                isActive = false;
            }
            else
            {
                // Si las luces están apagadas, las enciende instanciando el prefab
                lightsInstance = Instantiate(lightsPrefab, transform.position, transform.rotation, transform);
                lightsInstance.transform.localPosition = new Vector3(0f, 2f, 0f); // ajusta la altura de la luz a 2 unidades sobre el objeto
                isActive = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            // Comprueba si el objeto se ha movido lo suficiente
            Vector3 currentPosition = transform.position;
            float distanceMoved = Vector3.Distance(currentPosition, previousPosition);
            if (distanceMoved < MIN_MOVE_DISTANCE)
            {
                return;
            }

            // Crea la instancia de la luz y ajusta su posición y rotación
            lightsInstance = Instantiate(lightSpeed, currentPosition, transform.rotation, transform);
            lightsInstance.transform.localPosition = new Vector3(0f, -1f, 0f);

            // Obtiene la dirección del movimiento
            Vector3 moveDirection = currentPosition - previousPosition;
            moveDirection.Normalize();

            // Invierte la dirección para apuntar hacia atrás
            Vector3 lightDirection = -moveDirection;

            // Rota la luz en la dirección opuesta al movimiento
            lightsInstance.transform.rotation = Quaternion.LookRotation(lightDirection);

            // Actualiza la previousPosition con la posición actual del objeto
            previousPosition = currentPosition;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            Destroy(lightsInstance);
        }
    }
}
