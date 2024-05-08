using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    private Transform[] waypoints;
    public int targetPoint;
    public float toleranceDistance = 0.5f;

    private float smallSpeed = 8f;
    private float medSpeed = 5f;
    private float bigSpeed = 3f;

    private int smallDmg = 1;
    private int medDmg = 2;
    private int bigDmg = 3;

    private int smallHP = 1;
    private int medHP = 2;
    private int bigHP = 3;

    [SerializeField] private float enemySpeed;
    private int enemyDmg;
    private int enemyHP;

    private void OnEnable()
    {
        waypoints = FindObjectOfType<WayPointManager>().GetWaypoints();
        targetPoint = 0;
        SetEnemyType();

    }

    private void Update()
    {
        if (this != null)
        {
            Movement();
        }
       
    }
    public void Movement()
    {
        float dt = Time.deltaTime;
        Vector3 movementDirection = (waypoints[targetPoint].position - transform.position).normalized;
        transform.forward = movementDirection;
        transform.Translate(movementDirection * dt * enemySpeed, Space.World);
        float distanceToWp = Vector3.Distance(transform.position, waypoints[targetPoint].position);
        if (distanceToWp <= toleranceDistance)
        {
            targetPoint += 1;
            if (targetPoint == waypoints.Length)
            {
                gameObject.SetActive(false);
                Attack();
            }
        }
    }

    private void SetEnemyType()
    {
        if (this.tag == "EnemySmall")
        {
            enemySpeed = smallSpeed;
            enemyDmg = smallDmg;
            enemyHP = smallHP;
            Debug.Log("Small enemy spawned");
        }
        else if (this.tag == "EnemyMedium")
        {
            enemySpeed = medSpeed;
            enemyDmg = medDmg;
            enemyHP = medHP;
            Debug.Log("Medium enemy spawned");
        }
        else if (this.tag == "EnemyBig")
        {
            enemySpeed = bigSpeed;
            enemyDmg = bigDmg;
            enemyHP = bigHP;
            Debug.Log("Big enemy spawned");
        }

        else
        {
            Debug.Log("Error: Enemy Tag not found");
        }
    }

    private void Attack()
    {
        Debug.Log("Enemy hit");
    }
}
