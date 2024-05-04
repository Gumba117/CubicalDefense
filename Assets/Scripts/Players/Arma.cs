using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : PoolManager
{
    //Cadencia
    public float cadencia = 0.25f;

    //Disparo
    [SerializeField] private float ultimoDisparo;
    public float cooldown;
    [SerializeField] Transform jugador;
    [SerializeField] KeyCode key;
    private Arma[] armas;
    private float velocidadBala;
    private float dañoBala;

    [SerializeField] enum TipoDisparo
    {
        AK47,
        Francotirador,
        Escopeta
    }
    [SerializeField] TipoDisparo tipoDisparo;
    private void Awake()
    {
        ultimoDisparo = Time.time;

        if (gameObject.GetComponentsInChildren<Arma>() != null)
        {
            armas = gameObject.GetComponentsInChildren<Arma>();
        }

    }
    void Update()
    {
        //Disparar
        switch (tipoDisparo)
        {
            case TipoDisparo.AK47:
                cadencia = 0.15f;
                velocidadBala = 50;
                dañoBala = 1;
                Disparar();
            break;
            case TipoDisparo.Francotirador:
                cadencia = 2f;
                velocidadBala = 100;
                dañoBala = 3;
                Disparar();
            break;
            case TipoDisparo.Escopeta: /////////////////////(Todavia no fuciona la escopeta) Vid Que puede ayudar https://www.youtube.com/watch?v=bqNW08Tac0Y
                cadencia = 0.5f;
                velocidadBala = 15;
                dañoBala = 2;
                DispararEscopeta();
            break;
        }    
        cooldown += Time.deltaTime;
        cooldown = Mathf.Clamp(cooldown, 0, cadencia);
        Escopetas(tipoDisparo);
        
    }
    public override GameObject PedirObjeto()
    {
        GameObject Objeto = base.PedirObjeto();
        Objeto.transform.position = transform.position;
        //Objeto.transform.rotation = jugador.rotation;
        Objeto.SetActive(true);
        Objeto.GetComponent<Bala>().MovBala(gameObject.transform, velocidadBala, dañoBala);

        return Objeto;
    }

    public void Disparar()
    {
        if (Input.GetKey(key)) /////////////////////////////////////////////////////////////////
        {
            if (ultimoDisparo < Time.time)
            {
                ultimoDisparo = Time.time + cadencia;
                PedirObjeto();
                cooldown = 0;
            }
        }
    }

    public void DispararEscopeta()
    {
        if (Input.GetKey(key)) /////////////////////////////////////////////////////////////////
        {
            foreach (Arma arma in armas)
            {
                arma.Disparar();
            }
        }
    }

    private void Escopetas(TipoDisparo tipo)
    {
        if (gameObject.name == "Arma")//Yipeeeee cometiendo CRIMENES para que funcione la escopeta :c
        {
            if (tipo == TipoDisparo.Escopeta)
            {
                armas[1].gameObject.SetActive(true);
                armas[2].gameObject.SetActive(true);
            }
            else
            {
                armas[1].gameObject.SetActive(false);
                armas[2].gameObject.SetActive(false);
            }
        }
    }   
}
