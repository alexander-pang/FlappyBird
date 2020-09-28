using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class MainMenu : MonoBehaviour
{
    public static bool isTwoPlayerGame;

    private void Awake()
    {
        if (PlayerPrefs.GetInt("MusicOn", 0) == 1)
        {
            FindObjectOfType<AudioManager>().PlayIfNotPlaying("ThemeSong");
        }  
    }
    public void Play1Bird()
    {
        SceneManager.LoadScene("Main");
        isTwoPlayerGame = false;
    }
    public void Play2Bird()
    {
        SceneManager.LoadScene("2Birds");
        isTwoPlayerGame = true;
        //GameControl.instance.isTwoBirdGame = true;
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void highScores()
    {
        SceneManager.LoadScene("HighScores");
    }
}
