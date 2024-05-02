using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mira : MonoBehaviour
{

    public float velocity;
    
    public float limitesy;
    public float limitesx;
    

    void Update()
    {
        MovMira();
    }
    public void Limites()
    {
        Vector3 Posicion = transform.position;
        Posicion.y = Mathf.Clamp(Posicion.y, -limitesy, limitesy);
        Posicion.x = Mathf.Clamp(Posicion.x, -limitesx, limitesx);
        transform.position = Posicion;
    }
    public void MovMira()
    {
        transform.Translate(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized * Time.deltaTime * velocity);
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
