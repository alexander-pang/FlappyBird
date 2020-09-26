using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class MainMenu : MonoBehaviour
{
    public static bool isTwoPlayerGame;
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
        Debug.Log("Quit");
        Application.Quit();
    }
}
