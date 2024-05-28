
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float puntajeMaximo;
    public string nombreJugador;

    public PlayerData(ScoreManager puntaje)
    {
        if (puntaje.score > puntajeMaximo)
        {

            puntajeMaximo = puntaje.score;
            //nombreJugador = puntaje.s;
        }
    }
}