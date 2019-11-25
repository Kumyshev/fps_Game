using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    float timeLeft = 60.0f;

    public static int time;

    public static string timer;
    public static bool timerformenu = false;

    public Text pouseMenu;
    

    void Start()
    {
        
        
    }
    void Update()
    {
        timeLeft -= Time.deltaTime;
        pouseMenu.text = "TIMER: " + Mathf.Round(timeLeft);
        timer = pouseMenu.text;
        time = Convert.ToInt32(timeLeft);
        PlayerPrefs.SetInt("Timer", time);


        if (timeLeft < 0)
        {
            //SceneManager.LoadScene("Menu");
            timerformenu = true;
            
        }
    }
}
