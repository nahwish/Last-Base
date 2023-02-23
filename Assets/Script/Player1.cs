using UnityEngine;

/// <summary>
/// Clase que controla el movimiento del objeto en el juego.
/// </summary>
public class Player1 : MonoBehaviour
{
    /// <summary>
    /// Se actualiza el movimiento del objeto en cada frame.
    /// </summary>
    void Update()
    {
        Movimiento();
    }

    /// <summary>
    /// Controla el movimiento del objeto en el juego.
    /// </summary>
    void Movimiento (){
        // Obtiene la entrada del jugador en el eje vertical.
        float vertical = Input.GetAxis("Vertical");

        // Obtiene la entrada del jugador en el eje horizontal.
        float horizontal = Input.GetAxis("Horizontal");

        // Velocidad de movimiento estándar.
        float movimientoStandar = 15f;
      
        // Crea un vector de movimiento para el objeto.
        Vector3 movimientoJugador = new Vector3(horizontal,0,vertical);

        // Mueve el objeto con el vector de movimiento y la velocidad estándar.
        transform.Translate(movimientoJugador * movimientoStandar * Time.deltaTime);

        
    }
}
