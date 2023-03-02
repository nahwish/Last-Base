using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspiralFuego : MonoBehaviour
{
    private GameObject lightsInstance;
    [SerializeField]
    [Tooltip("Prefab a instanciar")]
    private GameObject lightsPrefab;
    private bool isActive = false;
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
        }
    }
}
