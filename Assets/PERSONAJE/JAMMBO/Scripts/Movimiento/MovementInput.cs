using UnityEngine;

public class MovementInput : MonoBehaviour {

[SerializeField] private Animator anim;
[Tooltip("Velocidad normal para caminar")] [SerializeField] [Range(1,15)]private float walkSpeed = 7f;
[Tooltip("Velocidad al correr con Shift")] [SerializeField] [Range(1,15)]private float runSpeed = 12f;
[Tooltip("Velocidad de rotacion del Player")] [SerializeField] [Range(1,50)] private float SpeedRotation = 30;

private Rigidbody rb;
private Vector3 directionCharacter;

private void Start() {
    rb = GetComponent<Rigidbody>();
}

private void Update() {
    Movement();
    RotationPlayer();
}

private void Movement() {
    float vertical = Input.GetAxis("Vertical"); // Obtiene la entrada del eje vertical
    float horizontal = Input.GetAxis("Horizontal"); // Obtiene la entrada del eje horizontal

    float movementSpeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed; // Si la tecla Shift izquierda está siendo presionada, establece la velocidad de movimiento en la velocidad de carrera (runSpeed), de lo contrario, establece la velocidad de movimiento en la velocidad de caminata (walkSpeed).
    directionCharacter = new Vector3(horizontal, 0f, vertical); // Crea un nuevo vector de dirección basado en las entradas horizontales y verticales

    if (directionCharacter.magnitude > 0f) { // Si el vector de dirección tiene magnitud mayor a 0, es decir, si el personaje está en movimiento
        rb.AddForce(directionCharacter * movementSpeed); // Agrega una fuerza al rigidbody del personaje en la dirección y velocidad de movimiento especificadas
        anim.SetFloat("Blend", movementSpeed); // Establece el valor de la variable "Blend" en el animator al valor de la velocidad de movimiento, lo que puede ser usado para controlar la animación del personaje.
    } else { // Si el personaje no se está moviendo
        anim.SetFloat("Blend", 0f); // Establece el valor de la variable "Blend" en el animator a 0, lo que puede ser usado para controlar la animación del personaje.
    }

    transform.Translate(directionCharacter * movementSpeed * Time.deltaTime); // Mueve el objeto transformado del personaje en la dirección y velocidad de movimiento especificadas
}

void RotationPlayer(){
    if (Input.GetKey(KeyCode.LeftArrow))transform.Rotate(Vector3.up, -SpeedRotation * Time.deltaTime);
    if (Input.GetKey(KeyCode.RightArrow))transform.Rotate(Vector3.up, SpeedRotation * Time.deltaTime);    
}
}