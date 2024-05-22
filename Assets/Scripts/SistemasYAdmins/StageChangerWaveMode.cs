using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageChangerWaveMode : MonoBehaviour
{
    public GameObject[] stages;
    private int currentStageIndex = 0;
    private int waveNum;
    private int changeRate = 1; // Cambia de stage cada X rondas  

    void Update()
    {
        waveNum = EnemyWaveSpawner.waveIndex;

        if (waveNum % changeRate == 0 && waveNum != 0 && EnemyWaveSpawner.EnemiesAlive == 0)
        {
            stages[currentStageIndex].SetActive(false);

            currentStageIndex = (waveNum / changeRate) % stages.Length;

            stages[currentStageIndex].SetActive(true);
        }
    }
}
