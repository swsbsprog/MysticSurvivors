using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    public static StageManager instance;
    private void Awake() => instance = this;
    public int score;
    public Text scoreText;

    public void AddScore(int addScore)
    {
        score += addScore;
        scoreText.text = score.ToString();
    }
}
