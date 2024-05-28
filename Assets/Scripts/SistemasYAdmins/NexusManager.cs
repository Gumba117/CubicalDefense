using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NexusManager : MonoBehaviour
{
    private float nexusMedHealth;
    private float nexusLowHealth;
    public float nexusCurrentHealth;

    private MeshRenderer nexus;
    public Material[] nexusMaterials;

    public CamEffects camEffects;

    GameObject gameOver;

    private void OnEnable()
    {
        nexus = GetComponent<MeshRenderer>();
        camEffects = FindObjectOfType<CamEffects>();
        //gameOver = FindObjectOfType<GameOver>().gameObject;
        nexusCurrentHealth = NexusHealth.nexusHealth;
        nexusMedHealth = NexusHealth.nexusMaxHealth / 2f;
        nexusLowHealth = NexusHealth.nexusMaxHealth / 4f;

        

    }

    private void Update()
    {
        CheckHP();
        CheckColor();
    }

    public void NexusTakeDamage(float damage)
    {

        if (nexusCurrentHealth > 0)
        {
            camEffects.ShakeCamera(2f, 0.5f);
            nexusCurrentHealth = nexusCurrentHealth - damage;
            NexusHealth.nexusHealth = nexusCurrentHealth;
        }
        
    }

    private void CheckHP()
    {
        if (nexusCurrentHealth <= 0)
        {
            //Debug.Log("Game Over");
            //Time.timeScale = 0;
            //SceneManager.LoadScene("GameOver");
            //gameOver.SetActive(true);

        }
    }

    private void CheckColor()
    {
        if (nexusCurrentHealth <= nexusMedHealth && nexusCurrentHealth > nexusLowHealth)
        {
            nexus.material = nexusMaterials[1];
        }
        else if (nexusCurrentHealth <= nexusLowHealth)
        {
            nexus.material = nexusMaterials[2];
        }
        else
        {
            nexus.material = nexusMaterials[0];
        }
    }
}
