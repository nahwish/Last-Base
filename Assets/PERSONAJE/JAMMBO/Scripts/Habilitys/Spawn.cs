using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    private GameObject lightsInstance;
    private GameObject fireInstance;
    [SerializeField]
    [Tooltip("Prefab a instanciar 1")]
    private GameObject lightsPrefab;
    [SerializeField]
    [Tooltip("Prefab a instanciar 2")]
    private GameObject sprayFuego;
    private bool isActive = false;
    private bool fuegoIsActive = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
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
                lightsInstance.transform.localPosition = new Vector3(0f, 0.5f, 0f); // ajusta la altura de la luz a 2 unidades sobre el objeto
                isActive = true;
            }
                // Destroy(lightsInstance,7.5f);

        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (fuegoIsActive)
            {
                // Si las luces ya están activas, las apaga destruyendo la instancia
                Destroy(fireInstance);
                fuegoIsActive = false;
            }
            else
            {
                // Si las luces están apagadas, las enciende instanciando el prefab
                fireInstance = Instantiate(sprayFuego, transform.position, transform.rotation, transform);
                fireInstance.transform.localPosition = new Vector3(0f, 0.5f, 0f); // ajusta la altura de la luz a 2 unidades sobre el objeto
                fuegoIsActive = true;
            }
        
        }
    }
}
