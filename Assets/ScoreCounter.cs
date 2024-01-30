using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public static int score; // Make score a static variable

    void Start()
    {
        score = 0;
    }

    void Update()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}