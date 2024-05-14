using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bala : MonoBehaviour
{
    [SerializeField] public Rigidbody rigidbodyBala;
    [SerializeField] public float velocidad;
    [SerializeField] public int dañoBala = 1;

    private void Awake()
    {
        rigidbodyBala=GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (transform.position.y<=-1f)
        {
            gameObject.SetActive(false);
            rigidbodyBala.velocity = Vector3.zero;

        }
    }
    public void MovBala(Transform dir, float vel, float daño)
    {
        velocidad= vel;
        transform.rotation = dir.rotation;
        rigidbodyBala.AddForce(dir.forward*velocidad, ForceMode.Impulse);
      
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<EnemyMovement>())
        {
            other.GetComponent<EnemyMovement>().EnemyHit(dañoBala);
            Debug.Log("Bullet impact");
            gameObject.SetActive(false);
            rigidbodyBala.velocity = Vector3.zero;

        }
    }

}
