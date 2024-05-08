using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject smallEnemy;
    public GameObject medEnemy;
    public GameObject bigEnemy;

    public Transform enemySpawnPoint;

    public void SpawnEnemy(int i)
    {
        switch (i)
        {
            case 0:
                Instantiate(smallEnemy,enemySpawnPoint.position, Quaternion.identity); 
                break;
            case 1:
                Instantiate(medEnemy, enemySpawnPoint.position, Quaternion.identity);
                break;
            case 2:
                Instantiate(bigEnemy, enemySpawnPoint.position, Quaternion.identity);
                break;

                default:
                Debug.Log("Error");
                break;
        }
    }
}
