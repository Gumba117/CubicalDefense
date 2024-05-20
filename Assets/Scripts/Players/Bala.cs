using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public Rigidbody rigidbodyBala;
    [SerializeField] public float velocidad;
    [SerializeField] public float da�oBala = 1;

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
    public void MovBala(Transform dir, float vel, float da�o)
    {
        //Debug.Log("hola soy bala");
        da�oBala = da�o;
        velocidad= vel;
        transform.rotation = dir.rotation;
        rigidbodyBala.AddForce(dir.forward*velocidad, ForceMode.Impulse);
      
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<EnemyMovement>())
        {
            other.GetComponent<EnemyMovement>().EnemyHit(da�oBala);
            //Debug.Log("Bullet impact");
            trilRenderer.Clear();
            rigidbodyBala.velocity = Vector3.zero;
            gameObject.SetActive(false);

        }
    }

}
