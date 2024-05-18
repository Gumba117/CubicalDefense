using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class ScoreManager : MonoBehaviour
{
    private int score;
    public TextMeshProUGUI scoreText;

    private void Update()
    {
        scoreText.text = score.ToString();
    }

    public void UpdateScore(int points)
    {
        score = score + points;
    }
}
