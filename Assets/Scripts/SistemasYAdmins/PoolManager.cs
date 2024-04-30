using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    //El pool manager es el padre de los spawns
    public GameObject objeto;
    public List<GameObject> objetosCreados;

    private void Awake()
    {
        objetosCreados = new List<GameObject>();
    }
    public virtual GameObject PedirObjeto()
    {
        for (int i = 0; i < objetosCreados.Count; i++)
        {
            if (!objetosCreados[i].activeInHierarchy)
            {
                return objetosCreados[i];
            }
        }
        GameObject nuevo = CrearObjeto();
        objetosCreados.Add(nuevo);
        return nuevo;
    }
    public GameObject CrearObjeto()
    {
        return Instantiate(objeto);
    }
}
