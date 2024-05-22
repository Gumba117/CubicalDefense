using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NexusHealth : MonoBehaviour
{
    public static float nexusHealth;
    [HideInInspector] public static float nexusMaxHealth = 100f;
    private NexusManager firstNexus;
    void Awake()
    {
        nexusHealth = nexusMaxHealth;
        firstNexus = FindObjectOfType<NexusManager>();
        firstNexus.nexusCurrentHealth = nexusHealth;
        firstNexus.camEffects = FindObjectOfType<CamEffects>();
    }

}
