using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class ScoreManager : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scoreFinText;

    private void Update()
    {
        scoreText.text = score.ToString();
        scoreFinText.text = "Tu puntaje:" + score;

    }

    public void UpdateScore(int points)
    {
        score = score + points;
    }


    public void GuardarPuntaje()
    {
        if (SaveMamager.LoadPlayerScore() == null)
        {
            //nombreJugador = inputname.text;
            SaveMamager.SavePlayerScore(this);
        }
        else
        {
            if (SaveMamager.LoadPlayerScore().puntajeMaximo < score)
            {
                //nombreJugador = inputname.text;
                SaveMamager.SavePlayerScore(this);
            }
        }


    }
}
