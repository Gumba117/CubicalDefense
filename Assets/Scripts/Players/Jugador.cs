using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Jugador : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        MirarAlMouse();
    }
    void MirarAlMouse() //Podemos usar un objeto y moverlo con el controlador y que siga el objeto
    {
        Vector3 mouse = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        Vector3 direccion = mouse - pos;
        float angle = Mathf.Atan2(direccion.x, direccion.y) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(new Vector3(0, angle, 0));
    }
}
