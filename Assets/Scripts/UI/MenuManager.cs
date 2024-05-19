using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("ModoInfinito");
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Salir del juego");
    }
}
