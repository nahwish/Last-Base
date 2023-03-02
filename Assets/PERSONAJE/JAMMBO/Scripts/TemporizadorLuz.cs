using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporizadorLuz : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Tiempo maximo que espera el objeto para destruirse")]
    private float time;

    void Start()
    {
        Destroy(gameObject,time);
    } 
}
