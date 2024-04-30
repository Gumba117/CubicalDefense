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
    public void MovBala(Transform dir)
    {
        transform.rotation = dir.rotation;
        rigidbodyBala.AddForce(dir.right*velocidad, ForceMode.Impulse);
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        if (other != null) 
        {
            rigidbodyBala.velocity = Vector3.zero;
            gameObject.SetActive(false);
        }
    }
}
