using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public Text highScoreTextEntry;
    public void addHighScore()
    {
        HighScoreManager.instance.SaveHighScore(highScoreTextEntry.text, GameControl.instance.score);
    }
}
