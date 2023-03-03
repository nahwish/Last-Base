using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Linterna : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Prefab a instanciar")]
    private GameObject lightsPrefab;
   
    private GameObject lightsInstance; // variable para almacenar la instancia de las luces
    private bool isActive = false;
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

    }
}
