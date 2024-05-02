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
        
    }
    void Update()
    {
        //Disparar
        switch (tipoDisparo)
        {
            case TipoDisparo.AK47:
                cadencia = 0.15f;
                Disparar(false);
            break;
            case TipoDisparo.Francotirador:
                cadencia = 2f;
                Disparar(false);
            break;
            case TipoDisparo.Escopeta: /////////////////////(Todavia no fuciona la escopeta) Vid Que puede ayudar https://www.youtube.com/watch?v=bqNW08Tac0Y
                cadencia = 0.5f;
                Disparar(false);
            break;
        }

            
        cooldown += Time.deltaTime;
        cooldown = Mathf.Clamp(cooldown, 0, cadencia);
    }
    public override GameObject PedirObjeto()
    {
        GameObject Objeto = base.PedirObjeto();
        Objeto.transform.position = transform.position;
        //Objeto.transform.rotation = jugador.rotation;
        Objeto.SetActive(true);
        Objeto.GetComponent<Bala>().MovBala(jugador);

        return Objeto;
    }

    public void Disparar(bool escopeta)
    {
        if (Input.GetKey(key)&& escopeta== false) /////////////////////////////////////////////////////////////////
        {
            if (ultimoDisparo < Time.time)
            {
                ultimoDisparo = Time.time + cadencia;
                PedirObjeto();
                cooldown = 0;
            }
        }
        else if (Input.GetKey(key)&& escopeta == true)
        {
            if (ultimoDisparo < Time.time)
            {
                ultimoDisparo = Time.time + cadencia;
                for (int i = 0; i < 5; i++)
                {
                    PedirObjeto();
                }
                cooldown = 0;
            }
        }
    }
}
