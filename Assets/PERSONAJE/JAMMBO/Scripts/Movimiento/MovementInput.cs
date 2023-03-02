
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script requires you to have setup your animator with 3 parameters, "InputMagnitude", "InputX", "InputZ"
//With a blend tree to control the inputmagnitude and allow blending between animations.
[RequireComponent(typeof(CharacterController))]
public class MovementInput : MonoBehaviour {
 public float jumpForce = 7f;
    public float Velocity;
    [Space]
	public float InputX;
	public float InputZ;
	public Vector3 desiredMoveDirection;
	public Animator anim;
	public float Speed;
	public float allowPlayerRotation = 0.1f;
	public CharacterController controller;
	public bool isGrounded;

    [Header("Animation Smoothing")]
    [Range(0,1f)]
    public float StartAnimTime = 0.3f;

	// Use this for initialization
	void Start () {
		anim = this.GetComponent<Animator> ();
		controller = this.GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
		Movimiento();
		RotationPlayer();
    }


void Movimiento() {
    float vertical = Input.GetAxis("Vertical");
    float horizontal = Input.GetAxis("Horizontal");
    float movimientoStandar = 12f;
    Rigidbody rb = GetComponent<Rigidbody>();
    
    if (Input.GetKey(KeyCode.LeftShift)) {
        movimientoStandar = 12f;
       
    } else {
        movimientoStandar = 7f;
    }

    desiredMoveDirection = new Vector3(horizontal, 0f, vertical);

    if (desiredMoveDirection.magnitude > 0f) {
        // Aquí aplicamos la fuerza al Rigidbody en la dirección deseada
        rb.AddForce(desiredMoveDirection * movimientoStandar);
        anim.SetFloat("Blend", movimientoStandar, StartAnimTime, Time.deltaTime);
    } else {
        anim.SetFloat("Blend", 0f);
    }
    // Aquí también puedes aplicar un movimiento usando transform.Translate si lo necesitas
    transform.Translate(desiredMoveDirection * movimientoStandar * Time.deltaTime);
}



void RotationPlayer(){
     if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.up, -Speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.up, Speed * Time.deltaTime);
        }
}
}

