using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HighScoreManager : MonoBehaviour
{

    public static HighScoreManager instance;
    public const int leaderboardLength = 5;
    public Text highScoreTextEntry;
    public GameObject entryUI;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    public void SaveHighScore(string name, int score)
    {
        List<string> highScoreNames = new List<string>();
        List<int> HighScores = new List<int>();

        int i = 1;
        while (i <= leaderboardLength && PlayerPrefs.HasKey("HighScore" + i + "score"))
        {
            int tempScore = PlayerPrefs.GetInt("HighScore" + i + "score");
            
            string tempName = PlayerPrefs.GetString("HighScore" + i + "name");

            HighScores.Add(tempScore);
            highScoreNames.Add(tempName);
            i++;
        }
        if (HighScores.Count == 0)
        {
            HighScores.Add(score);
            highScoreNames.Add(name);
        }
        else
        {
            for (i = 1; i <= HighScores.Count && i <= leaderboardLength; i++)
            {
                if (score > HighScores[i - 1])
                {
                    HighScores.Insert(i - 1, score);
                    highScoreNames.Insert(i - 1, name);
                    break;
                }
                if (i == HighScores.Count && i < leaderboardLength)
                {
                    HighScores.Add(score);
                    highScoreNames.Add(name);
                    break;
                }
            }
        }

        i = 1;
        while (i <= leaderboardLength && i <= HighScores.Count)
        {
            PlayerPrefs.SetString("HighScore" + i + "name", highScoreNames[i - 1]);
            PlayerPrefs.SetInt("HighScore" + i + "score", HighScores[i - 1]);
            i++;
        }
    }

    public bool isAHighScore(int score)
    {
        int i = 1;
        while (i <= leaderboardLength && PlayerPrefs.HasKey("HighScore" + i + "score"))
        {

            int tempScore = PlayerPrefs.GetInt("HighScore" + i + "score");
            if(score > tempScore)
            {
                return true;
            }
            i++;
        }

        if(i <= leaderboardLength)
        {
            return true;
        }
        return false;
    }

    public void addHighScore()
    {
        SaveHighScore(highScoreTextEntry.text, GameControl.instance.score);
        entryUI.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void backButton()
    {
        SceneManager.LoadScene("Menu");
    }
}
