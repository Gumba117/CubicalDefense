using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public Transform[] waypoints;
    public int targetPoint;
    public float speed;
    public float toleranceDistance = 0.3f;

    private void Start()
    {
        targetPoint = 0;

    }

    private void Update()
    {
        Movement();
    }
    public void Movement()
    {
        float dt = Time.deltaTime;
        Vector3 movementDirection = (waypoints[targetPoint].position - transform.position).normalized;
        transform.forward = movementDirection;
        transform.Translate(movementDirection * dt * speed, Space.World);
        float distanceToWp = Vector3.Distance(transform.position, waypoints[targetPoint].position);
        if (distanceToWp <= toleranceDistance)
        {
            targetPoint += 1;
            if (targetPoint == waypoints.Length)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
