using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScore : MonoBehaviour
{
    
    public static int scoreValue;

    public Text Scores;
    public Text endScores;
    void Start()
    {
        scoreValue = 0;
    }

    
    void Update()
    {
        endScores.text = scoreValue.ToString();
        Scores.text = scoreValue.ToString();
        if (scoreValue >= PlayerPrefs.GetInt("GameScore", 0) && MobileFirstPersonInput.gameFinish == true)
        {
            PlayerPrefs.SetInt("GameScore", scoreValue);
        }


    }
}
