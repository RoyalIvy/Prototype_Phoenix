using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scorer : MonoBehaviour
{
    [SerializeField] private GameObject player;

    [Space]

    [SerializeField] private Text scorerText;
    [SerializeField] private Text highScoreText;

    [Space]

    [SerializeField] private int multiplierScore;

    private int score;
    private int highScore;
    private float scoreFloat;

    private void Awake()
    {
        score = 0;
        PlayerPrefs.SetInt("score", score);
    }

    private void Start()
    {
        score = PlayerPrefs.GetInt("score");
        highScore = PlayerPrefs.GetInt("highScore");
    }
    private void Update()
    {
        scoreFloat += Time.deltaTime * multiplierScore;
        score = (int)scoreFloat;
        scorerText.text = score.ToString();

        if (score >= highScore) // подсчет рекорда
        {
            highScore = score;
        }

        highScoreText.text = highScore.ToString();

        PlayerPrefs.SetInt("score", score);
        PlayerPrefs.SetInt("highScore", highScore);
    }
}
