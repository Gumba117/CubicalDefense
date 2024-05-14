using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Mira : MonoBehaviour
{

    public float velocity;
    
    public Vector2 limitesy;
    public Vector2 limitesx;

    public Vector2 movInput;

    void Update()
    {
        MovMira();
    }
    public void Limites()
    {
        Vector3 Posicion = transform.position;
        Posicion.z = Mathf.Clamp(Posicion.z, limitesy.x, limitesy.y);
        Posicion.x = Mathf.Clamp(Posicion.x, limitesx.x, limitesx.y);
        transform.position = Posicion;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movInput = context.ReadValue<Vector2>();
    }

    public void MovMira()
    {
        transform.Translate(new Vector3(movInput.x, movInput.y, 0).normalized * Time.deltaTime * velocity);
        Limites();

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            velocity = 40;
        }
        else
        {
            velocity = 20;
        }
    }
}
