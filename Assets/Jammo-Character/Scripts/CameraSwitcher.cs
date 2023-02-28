using System.Collections;
using System.Collections.Generic;
// Este script cambia entre dos cámaras al presionar la tecla T.
// La primera vez que se presiona la tecla T, se activa la segunda cámara.
// La segunda vez que se presiona la tecla T, se activa la primera cámara.

using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    // Las dos cámaras que se van a alternar
    public GameObject cam1;
    public GameObject cam2;

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
                if (!cam2.activeSelf)
                {
                    cam2.SetActive(true);
                }

                // Si la primera cámara está activa, desactívala
                if (cam1.activeSelf)
                {
                    cam1.SetActive(false);
                }
            }
            // Si "isActive" es falso, cambia a la primera cámara
            else
            {
                // Si la primera cámara no está activa, actívala
                if (!cam1.activeSelf)
                {
                    cam1.SetActive(true);
                }

                // Si la segunda cámara está activa, desactívala
                if (cam2.activeSelf)
                {
                    cam2.SetActive(false);
                }
            }
        }
    }
}
