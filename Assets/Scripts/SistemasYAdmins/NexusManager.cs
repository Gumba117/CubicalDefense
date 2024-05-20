using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NexusManager : MonoBehaviour
{
    private float nexusMaxHealth = 100f;
    private float nexusMedHealth;
    private float nexusLowHealth;
    public float nexusCurrentHealth;

    public MeshRenderer nexus;
    public Material[] nexusMaterials;

    CamEffects camEffects;

    private void Start()
    {
        nexusCurrentHealth = nexusMaxHealth;
        nexusMedHealth = nexusMaxHealth / 2f;
        nexusLowHealth = nexusMaxHealth / 4f;

        camEffects = FindObjectOfType<CamEffects>();
    }

    private void Update()
    {
        CheckHP();

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

    public void NexusTakeDamage(float damage)
    {

        if (nexusCurrentHealth > 0)
        {
            camEffects.ShakeCamera(2f, 0.5f);
            nexusCurrentHealth = nexusCurrentHealth - damage;
        }
        
    }

    private void CheckHP()
    {
        if (nexusCurrentHealth <= 0)
        {
            //Debug.Log("Game Over");
            SceneManager.LoadScene("Menu");

        }
    }
}
