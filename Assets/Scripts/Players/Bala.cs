using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public Rigidbody rigidbodyBala;
    [SerializeField] public float velocidad;
    [SerializeField] public float dañoBala = 1;

    TrailRenderer trilRenderer;

    private void Awake()
    {
        rigidbodyBala=GetComponent<Rigidbody>();
        trilRenderer= GetComponent<TrailRenderer>();
    }
    private void Update()
    {
        if (transform.position.y<=-1f)
        {
            trilRenderer.Clear();
            rigidbodyBala.velocity = Vector3.zero;
            gameObject.SetActive(false);

        }
    }
    public void MovBala(Transform dir, float vel, float daño)
    {
        //Debug.Log("hola soy bala");
        dañoBala = daño;
        velocidad= vel;
        transform.rotation = dir.rotation;
        rigidbodyBala.AddForce(dir.forward*velocidad, ForceMode.Impulse);
      
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<EnemyMovement>())
        {
            other.GetComponent<EnemyMovement>().EnemyHit(dañoBala);
            //Debug.Log("Bullet impact");
            trilRenderer.Clear();
            rigidbodyBala.velocity = Vector3.zero;
            gameObject.SetActive(false);

        }
    }

}
