using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.UIElements;

public class testcanvasEnemy : MonoBehaviour
{
    public GameObject testCanvas;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !testCanvas.activeInHierarchy)
        {
            testCanvas.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && testCanvas.activeInHierarchy)
        {
            testCanvas.SetActive(false);
        }
    }
}