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

    private float smallDmg = 5f;
    private float medDmg = 10f;
    private float bigDmg = 20f;
    private float bossDmg = 100f;

    private float smallHP = 2f;
    private float medHP = 10f;
    private float bigHP = 35f;
    private float bossHP = 100f;

    private int smallPoints = 5;
    private int medPoints = 10;
    private int bigPoints = 20;
    private int bossPoints = 100;

    private float enemySpeed;
    private float enemyDmg;
    public float enemyHP;
    private int enemyPoints;
    private int enemyType;

    public GameObject dfxSmall;
    public GameObject dfxMedium;
    public GameObject dfxBig;
    public GameObject dfxBoss;

    private EnemyAnimations enemyAnimations;
    private NexusManager nexusManager;
    private ScoreManager scoreManager;


    private void OnEnable()
    {
        waypoints = FindObjectOfType<WayPointManager>().GetWaypoints();
        targetPoint = 0;
        SetEnemyType();
        enemyAnimations = GetComponent<EnemyAnimations>();
        nexusManager = FindObjectOfType<NexusManager>();
        scoreManager = FindObjectOfType<ScoreManager>();

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
            enemyPoints = smallPoints;
            enemyType = 1;
            //Debug.Log("Small enemy spawned");
        }
        else if (this.tag == "EnemyMedium")
        {
            enemySpeed = medSpeed;
            enemyDmg = medDmg;
            enemyHP = medHP;
            enemyPoints = medPoints;
            enemyType = 2;
            //Debug.Log("Medium enemy spawned");
        }
        else if (this.tag == "EnemyBig")
        {
            enemySpeed = bigSpeed;
            enemyDmg = bigDmg;
            enemyHP = bigHP;
            enemyPoints = bigPoints;
            enemyType = 3;
            //Debug.Log("Big enemy spawned");
        }
        else if (this.tag == "Boss")
        {
            enemySpeed = bossSpeed;
            enemyDmg = bossDmg;
            enemyHP = bossHP;
            enemyPoints = bossPoints;
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
        nexusManager.NexusTakeDamage(enemyDmg);
    }

    public void DestroyEnemy()
    {
        DeathEffect();
        scoreManager.UpdateScore(enemyPoints);
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

    public void EnemyHit(float i)
    {
        if (enemyHP > 0)
        {
            enemyHP = enemyHP - i;
            enemyAnimations.EnemyHitAnim();
        }
    }
}
