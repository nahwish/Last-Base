using System.Collections;
using System.Collections.Generic;
// Este script cambia entre dos cámaras al presionar la tecla T.
// La primera vez que se presiona la tecla T, se activa la segunda cámara.
// La segunda vez que se presiona la tecla T, se activa la primera cámara.

using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    // Las dos cámaras que se van a alternar
    public GameObject vistaAereaCam;
    public GameObject primeraPersonaCam;
    public GameObject visionCam;

    // Indica si la segunda cámara está activa
    bool isActive = false;

    void Update()
    {
        ControlCam();
    }

    void ControlCam()
{
    if (Input.GetKeyDown(KeyCode.T))
    {
        // Cambia la variable "isActive" para alternar entre las dos cámaras
        isActive = !isActive;

        // Si "isActive" es verdadero, cambia a la segunda cámara
        if (isActive)
        {
            // Si la segunda cámara no está activa, actívala
            if (!primeraPersonaCam.activeSelf)
            {
                primeraPersonaCam.SetActive(true);
            }

            // Si la primera cámara está activa, desactívala
            if (vistaAereaCam.activeSelf)
            {
                vistaAereaCam.SetActive(false);
            }
        }
        // Si "isActive" es falso, cambia a la primera cámara
        else
        {
            // Si la primera cámara no está activa, actívala
            if (!vistaAereaCam.activeSelf)
            {
                vistaAereaCam.SetActive(true);
            }

            // Si la segunda cámara está activa, desactívala
            if (primeraPersonaCam.activeSelf)
            {
                primeraPersonaCam.SetActive(false);
            }
        }
    }
    
    // Agregamos un nuevo if statement para detectar si la tecla C ha sido presionada
    if (Input.GetKeyDown(KeyCode.C))
    {
        // Activamos la cámara de visión
        visionCam.SetActive(true);

        // Desactivamos las otras cámaras
        vistaAereaCam.SetActive(false);
        primeraPersonaCam.SetActive(false);
    }
}

}
