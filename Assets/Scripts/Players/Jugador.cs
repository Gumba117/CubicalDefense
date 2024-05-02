using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Jugador : MonoBehaviour
{
    [SerializeField]GameObject mira;    
    void Update()
    {
        MirarALaMira();
    }
    void MirarALaMira()
    {
        transform.LookAt(mira.transform);
    }
}
