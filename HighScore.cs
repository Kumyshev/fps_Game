using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{



    public Text highpoint;
    public Text besttime;

    void Start()
    {

        highpoint.text = PlayerPrefs.GetInt("GameScore", 0).ToString();
        besttime.text = PlayerPrefs.GetInt("Timer", 0).ToString();

        GameFinish.gameFinish = false;
       
    }



    void Update()
    {
        

    }

    public void Reset()
    {
        PlayerPrefs.DeleteAll();
        highpoint.text = "0";
        besttime.text = "0";

    }

}
