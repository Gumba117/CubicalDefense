using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageChanger : MonoBehaviour
{
    public GameObject[] stages;
    private int currentStageIndex = 0;
    private int waveNum;
    private int changeRate = 2; // Cambia de stage cada X rondas
    private EnemySpawner enemySpawner;

    private void Start()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>(); 
    }

    void Update()
    {
        waveNum = enemySpawner.waveIndex;

        if (waveNum % changeRate == 0 && waveNum != 0 && EnemySpawner.EnemiesAlive == 0)
        {
            stages[currentStageIndex].SetActive(false);

            currentStageIndex = (waveNum / changeRate) % stages.Length;

            stages[currentStageIndex].SetActive(true);
        }
    }
}
