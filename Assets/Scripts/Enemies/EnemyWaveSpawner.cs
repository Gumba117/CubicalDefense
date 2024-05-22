using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class EnemyWaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;

    public Wave[] waves;

    private Transform spawnPoint;

    public float timeBetweenWaves = 5f;

    public float countdown = 2f;

    public TextMeshProUGUI waveIndexText;

    public static int waveIndex = 0;

    void Update()
    {
        if (waveIndex == waves.Length && EnemiesAlive==0)
        {
            SceneManager.LoadScene("Menu");
            Debug.Log("Ganaste!");
            this.enabled = false;
        }

        if (EnemiesAlive > 0)
        {
            return;
        }

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
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

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }

        waveIndex++;
    }

    void SpawnEnemy(GameObject enemy)
    {
        spawnPoint = FindObjectOfType<WayPointManager>().GetSpawnPoint();
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }
}
