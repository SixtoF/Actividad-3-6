using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed = 1.5f;
    public float RotationSpeed = 10.0f;
    private Rigidbody Physics;
    public float JumbForce = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        Physics = GetComponent<Rigidbody>();

        //fijamos el cursor del raton en el medio de la pantalla y lo ocultamos
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");//-1 si el ususario presiona izquierda, 1 si presiona derecha
        float vertical = Input.GetAxis("Vertical");//-1 si el ususario presiona abajo, 1 si presiona arriba
        transform.Translate(new Vector3(horizontal, 0, vertical) * Time.deltaTime * Speed);

        //Introducimos el movimiento de transformacion a traves del raton
        float rotacionY = Input.GetAxis("Mouse X");
        transform.Rotate(new Vector3(0, rotacionY, 0) * Time.deltaTime * RotationSpeed);

        //salto player
        if (Input.GetKeyDown(KeyCode.Space)) { 
            Physics.AddForce(new Vector3 (0, JumbForce, 0), ForceMode.Impulse);
        }
    }
}
