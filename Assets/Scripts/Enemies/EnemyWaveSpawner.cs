using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class EnemyWaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive;

    public Wave[] waves;

    private Transform spawnPoint;

    public float timeBetweenWaves = 5f;

    public float countdown;

    public TextMeshProUGUI waveIndexText;

    public static int waveIndex;

    private void Start()
    {
        countdown = 2f;
        EnemiesAlive = 0;
        waveIndex = 0;
    }

    void Update()
    {
        if (waveIndex >= waves.Length && EnemiesAlive == 0)
        {
            SceneManager.LoadScene("Menu");
            Debug.Log("Ganaste!");
            this.enabled = false;
            return;
        }

        if (EnemiesAlive > 0)
        {
            return;
        }

        if (countdown <= 0f)
        {
            if (waveIndex < waves.Length)
            {
                StartCoroutine(SpawnWave());
                countdown = timeBetweenWaves;
            }
            return;
        }

        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveIndexText.text = (waveIndex + 1).ToString();
    }

    IEnumerator SpawnWave()
    {

        Wave wave = waves[waveIndex];     
        EnemiesAlive = wave.count;

        waveIndex++;

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(wave.timeBetween);
        }

        
    }

    void SpawnEnemy(GameObject enemy)
    {
        spawnPoint = FindObjectOfType<WayPointManager>().GetSpawnPoint();
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }
}
