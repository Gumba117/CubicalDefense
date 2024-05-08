using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.UIElements;


public class GameManager : MonoBehaviour
{
    public Canvas testCanvas;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && !testCanvas.enabled)
        {
            testCanvas.enabled = true;
        }
        else if (Input.GetKeyDown(KeyCode.LeftShift) && testCanvas.enabled)
        {
            testCanvas.enabled = false;
        }
    }
}
