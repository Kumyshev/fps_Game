using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class PouseMenu : MonoBehaviour
{
    public static bool GameOut = false;
    public static bool GamePause = false;
    public GameObject EndMenu;
    public GameObject Pouse;
    public GameObject Fire;
    public GameObject Reload;
    public GameObject Switch;


    private void Update()
    {
        
        if (Timer.timerformenu == true)
        {
            End();
            Pouse.SetActive(false);
            

        }
        if (Time.timeScale == 0f)
        {
            Fire.SetActive(false);
            Reload.SetActive(false);
            Switch.SetActive(false);
        }
        else
        {
            Fire.SetActive(true);
            Reload.SetActive(true);
            Switch.SetActive(true);

        }
            

    }

    public void Resume()
    {
        //if (GameOut == false)
        //{
        
        Timer.timerformenu = false;
        //pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        //}
    }
    public void Restart()
    {
        
        Timer.timerformenu = false;
        SceneManager.LoadScene("Main");
        //pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }



    public void End()
    {
        EndMenu.SetActive(true);
        Time.timeScale = 0f;
        GameOut = true;
    }
    public void Pause()
    {

        
        //pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GamePause = true;
    }
    public void Quit()
    {
        Application.Quit();
        //SceneManager.LoadScene("Menu");
    }
}
