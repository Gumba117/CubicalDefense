using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    GameObject[] menuInicial;

    public void LoadScene(string Menu)
    {
        SceneManager.LoadScene(Menu);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Salir del juego");
    }

    public void Seleccion()
    {

        foreach (GameObject menu in menuInicial)
        {
            menu.SetActive(false);
        }

    }
}
