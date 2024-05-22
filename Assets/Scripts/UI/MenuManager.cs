using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEditor;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    GameObject[] menuInicial;
    [SerializeField]
    GameObject[] menuSeleccion;
    [SerializeField]
    GameObject[] menuArmas;

    [SerializeField]
    GameObject volver;

    private int modo;


    public void JugarInfinito()
    {
        SceneManager.LoadScene("ModoInfinito");
    }
    public void JugarOleadas()
    {
        SceneManager.LoadScene("ModoOleadas");//////////////////////////////////////Cambiar a Oleadas
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Salir del juego");
    }

    public void Seleccion()
    {
        volver.SetActive(true);
        foreach (GameObject menu in menuInicial)
        {
            menu.SetActive(false);
        }
        foreach (GameObject menu in menuSeleccion)
        {
            menu.SetActive(true);
        }
    }
    public void SelModo()
    {
        modo = menuSeleccion[1].GetComponent<TMP_Dropdown>().value;
    }
    public void Armas()
    {
        foreach (GameObject menu in menuSeleccion)
        {
            menu.SetActive(false);
        }
        if (GameManager.instance.coop)
        {
            menuArmas[0].SetActive(true);
            menuArmas[1].SetActive(true);
            switch (modo)
            {
                case 0:
                    menuArmas[3].SetActive(true);
                    break;
                case 1:
                    menuArmas[2].SetActive(true);
                    break;
            }
        }
        else
        {
            menuArmas[0].SetActive(true);
            
            switch (modo)
            {
                case 0:
                    menuArmas[3].SetActive(true);
                    break;
                case 1:
                    menuArmas[2].SetActive(true);
                    break;
            }
        }
        
    }
    public void Volver()
    {
        foreach (GameObject menu in menuSeleccion)
        {
            menu.SetActive(false);
        }
        foreach (GameObject menu in menuArmas)
        {
            menu.SetActive(false);
        }
        foreach (GameObject menu in menuInicial)
        {
            menu.SetActive(true);
        }
        volver.SetActive(false);
    }
    public void EsCoop()
    {
        int coop;
        coop = menuSeleccion[0].GetComponent<TMP_Dropdown>().value;
        if (coop==0)
        {
            GameManager.instance.coop = false;
        }
        else
        {
            GameManager.instance.coop = true;
        }
    }
    public void TipoDisparo()
    {
        int tipoJ1;
        tipoJ1 = menuArmas[0].GetComponent<TMP_Dropdown>().value;
        switch (tipoJ1)
        {
            case 0:
                GameManager.instance.tipoDisparoJ1 = Arma.TipoDisparo.AK47;
                break;
            case 1:
                GameManager.instance.tipoDisparoJ1 = Arma.TipoDisparo.Francotirador;
                break;
            case 2:
                GameManager.instance.tipoDisparoJ1 = Arma.TipoDisparo.Escopeta;
                break;
        }
        int tipoJ2;
        tipoJ2 = menuArmas[1].GetComponent<TMP_Dropdown>().value;
        switch (tipoJ2)
        {
            case 0:
                GameManager.instance.tipoDisparoJ2 = Arma.TipoDisparo.AK47;
                break;
            case 1:
                GameManager.instance.tipoDisparoJ2 = Arma.TipoDisparo.Francotirador;
                break;
            case 2:
                GameManager.instance.tipoDisparoJ2 = Arma.TipoDisparo.Escopeta;
                break;
        }
        
    }
}
