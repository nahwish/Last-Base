using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookCamara : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public float movementSpeed = 5f;

    private float xRotation = 0f;
    private float yRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        yRotation += mouseX;

        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        float up = 0;

        if (Input.GetKey(KeyCode.Space))
        {
            up = 1;
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            up = -1;
        }

        Vector3 movement = transform.right * horizontal + transform.forward * vertical + transform.up * up;
        movement.Normalize();
        transform.position += movement * movementSpeed * Time.deltaTime;
    }
}
