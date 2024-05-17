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
    private float bossSpeed = 1f;

    private int smallDmg = 1;
    private int medDmg = 2;
    private int bigDmg = 3;
    private int bossDmg = 100;

    private int smallHP = 1;
    private int medHP = 2;
    private int bigHP = 3;
    private int bossHP = 25;

    private float enemySpeed;
    private int enemyType;
    private int enemyDmg;
    public int enemyHP;

    public GameObject dfxSmall;
    public GameObject dfxMedium;
    public GameObject dfxBig;
    public GameObject dfxBoss;

    private EnemyAnimations enemyAnimations;


    private void OnEnable()
    {
        waypoints = FindObjectOfType<WayPointManager>().GetWaypoints();
        targetPoint = 0;
        SetEnemyType();
        enemyAnimations = GetComponent<EnemyAnimations>();

    }

    private void Update()
    {
        if (this != null)
        {
            Movement();

            if (enemyHP <= 0)
            {
                DestroyEnemy();
            }
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
                EndPath();
                
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
            enemyType = 1;
            //Debug.Log("Small enemy spawned");
        }
        else if (this.tag == "EnemyMedium")
        {
            enemySpeed = medSpeed;
            enemyDmg = medDmg;
            enemyHP = medHP;
            enemyType = 2;
            //Debug.Log("Medium enemy spawned");
        }
        else if (this.tag == "EnemyBig")
        {
            enemySpeed = bigSpeed;
            enemyDmg = bigDmg;
            enemyHP = bigHP;
            enemyType = 3;
            //Debug.Log("Big enemy spawned");
        }
        else if (this.tag == "Boss")
        {
            enemySpeed = bossSpeed;
            enemyDmg = bossDmg;
            enemyHP = bossHP;
            enemyType = 4;
            //Debug.Log("BOSS SPAWNED!");
        }

        else
        {
            Debug.Log("Error: Enemy Tag not found");
        }
    }

    private void EndPath()
    {
        Attack();
        EnemySpawner.EnemiesAlive--;
        Destroy(gameObject);
    }

    private void Attack()
    {
        //Debug.Log("Enemy hit");
    }

    public void DestroyEnemy()
    {
        DeathEffect();
        EnemySpawner.EnemiesAlive--;
        Destroy(gameObject);
    }

    private void DeathEffect()
    {
        switch(enemyType)
        {
            case 1://small
                {
                    GameObject effect = (GameObject)Instantiate(dfxSmall, transform.position, Quaternion.identity);
                    Destroy(effect, 5f);
                    break;
                }
            case 2://med
                {
                    GameObject effect = (GameObject)Instantiate(dfxMedium, transform.position, Quaternion.identity);
                    Destroy(effect, 5f);
                    break;
                }
            case 3://big
                {
                    GameObject effect = (GameObject)Instantiate(dfxBig, transform.position, Quaternion.identity);
                    Destroy(effect, 5f);
                    break;
                }
            case 4://boss
                {
                    GameObject effect = (GameObject)Instantiate(dfxBoss, transform.position, Quaternion.identity);
                    Destroy(effect, 5f);
                    break;
                }
                default:
                Debug.Log("Error");
                break;
        }
    }

    public void EnemyHit(int i)
    {
        if (enemyHP > 0)
        {
            enemyHP = enemyHP - i;
            enemyAnimations.EnemyHitAnim();
        }
    }
}
