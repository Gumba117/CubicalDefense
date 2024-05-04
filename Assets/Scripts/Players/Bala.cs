using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    [SerializeField] public Rigidbody rigidbodyBala;
    [SerializeField] public float velocidad;
    [SerializeField] public float dañoBala = 1;

    private void Awake()
    {
        rigidbodyBala=GetComponent<Rigidbody>();
    }
    public void MovBala(Transform dir, float vel, float daño)
    {
        velocidad= vel;
        transform.rotation = dir.rotation;
        rigidbodyBala.AddForce(dir.forward*velocidad, ForceMode.Impulse);
      
    }
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other);
        if (other.name == "Cube")////////////////////////////////////////////////////////// MAS CRIMENES!!!!!!!!!!
        {
            rigidbodyBala.velocity = Vector3.zero;
            gameObject.SetActive(false);
        }
    }
}
