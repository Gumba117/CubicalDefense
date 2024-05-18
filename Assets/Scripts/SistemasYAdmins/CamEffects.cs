using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamEffects : MonoBehaviour
{
    private CinemachineVirtualCamera vCam;
    private float shakeTimer;

    private void Awake()
    {
        vCam = GetComponent<CinemachineVirtualCamera>();
    }

    public void ShakeCamera(float intensity, float time)
    {
        CinemachineBasicMultiChannelPerlin vCamSettings = vCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        vCamSettings.m_AmplitudeGain = intensity;
        shakeTimer = time;
    }

    private void Update()
    {
        if (shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;
            if (shakeTimer < 0f)
            {
                CinemachineBasicMultiChannelPerlin vCamSettings = vCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
                vCamSettings.m_AmplitudeGain = 0f;
            }
        }

    }
}
