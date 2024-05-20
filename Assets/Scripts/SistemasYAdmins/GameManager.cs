using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameManager : MonoBehaviour
{
    [SerializeField] public bool coop;

    public static GameManager instance;

    
    public Arma.TipoDisparo tipoDisparoJ1;
    public Arma.TipoDisparo tipoDisparoJ2;

    public int numJug;

    private void Awake()
    {
        
        if (GameManager.instance == null)
        {
            GameManager.instance = this;
           

            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }



    
   
}
