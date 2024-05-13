using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject smallEnemy;
    public GameObject medEnemy;
    public GameObject bigEnemy;
    public GameObject boss;

    public Transform enemySpawnPoint;

    private float timeBetweenWaves = 10f;
    private float timeBetweenEnemies = 0.5f;
    private float countdown = 2f;

    private int waveIndex = 0;

    private float[] spawnProbabilities = { 0.5f, 0.3f, 0.15f, 0.05f }; //PROBS: SMALL,MEDIUM,BIG,BOSS

    private void Update()
    {
        if(countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown-=Time.deltaTime;
    }

    IEnumerator SpawnWave()
    {
        waveIndex++;

        for(int i = 0; i < waveIndex; i++)
        {
            int enemyIndex = ChooseEnemyType();
            SpawnEnemy(enemyIndex);
            yield return new WaitForSeconds(timeBetweenEnemies);
        }
    }

    int ChooseEnemyType()
    {
        float randomValue = Random.value;
        float cumulativeProbability = 0f;

        for (int i = 0; i < spawnProbabilities.Length; i++)
        {
            cumulativeProbability += spawnProbabilities[i];
            if (randomValue <= cumulativeProbability)
            {
                return i;
            }
        }

        Debug.LogError("No se pudo seleccionar un tipo de enemigo.");
        return 0;
    }
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
            case 3:
                Instantiate(boss, enemySpawnPoint.position, Quaternion.identity);
                break;

            default:
                Debug.Log("Error");
                break;
        }
    }
}
