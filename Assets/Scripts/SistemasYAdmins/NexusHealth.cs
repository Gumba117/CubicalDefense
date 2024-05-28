using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NexusHealth : MonoBehaviour
{
    public static float nexusHealth;
    [HideInInspector] public static float nexusMaxHealth = 100f;
    private NexusManager firstNexus;

    public GameObject gameOver;
    void Awake()
    {
        nexusHealth = nexusMaxHealth;
        firstNexus = FindObjectOfType<NexusManager>();
        firstNexus.nexusCurrentHealth = nexusHealth;
        firstNexus.camEffects = FindObjectOfType<CamEffects>();
    }
    private void OnEnable()
    {
        nexusHealth = nexusMaxHealth;
        firstNexus = FindObjectOfType<NexusManager>();
        firstNexus.nexusCurrentHealth = nexusHealth;
        firstNexus.camEffects = FindObjectOfType<CamEffects>();

        Time.timeScale = 1;
    }
    private void Update()
    {
        if (nexusHealth==0||nexusHealth<0)
        {
            
                //Debug.Log("Game Over");
            Time.timeScale = 0;
            //SceneManager.LoadScene("GameOver");
            gameOver.SetActive(true);
        }
    }
}
