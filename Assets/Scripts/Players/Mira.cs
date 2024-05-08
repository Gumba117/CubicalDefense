using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mira : MonoBehaviour
{

    public float velocity;
    
    public Vector2 limitesy;
    public Vector2 limitesx;

    //private PlayerInput playerInput;



    void Awake()
    {
        //playerInput = GetComponent<PlayerInput>();

    }
    
    

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
    public void MovMira()
    {
        transform.Translate(new Vector3(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"), 0).normalized * Time.deltaTime * velocity);
        Limites();

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            velocity = 10;
        }
        else
        {
            velocity = 5;
        }
    }
}
