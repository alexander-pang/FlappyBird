using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HighScoreScence : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<canvas>().transform.Find("HighScore1").transform.Find("Name").transform.Find("Text").GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetString("HighScore1name", "Player 1");
        FindObjectOfType<canvas>().transform.Find("HighScore1").transform.Find("Score").transform.Find("Text").GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("HighScore1score", 0).ToString();

        FindObjectOfType<canvas>().transform.Find("HighScore2").transform.Find("Name").transform.Find("Text").GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetString("HighScore2name", "Player 2");
        FindObjectOfType<canvas>().transform.Find("HighScore2").transform.Find("Score").transform.Find("Text").GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("HighScore2score", 0).ToString();

        FindObjectOfType<canvas>().transform.Find("HighScore3").transform.Find("Name").transform.Find("Text").GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetString("HighScore3name", "Player 3");
        FindObjectOfType<canvas>().transform.Find("HighScore3").transform.Find("Score").transform.Find("Text").GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("HighScore3score", 0).ToString();

        FindObjectOfType<canvas>().transform.Find("HighScore4").transform.Find("Name").transform.Find("Text").GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetString("HighScore4name", "Player 4");
        FindObjectOfType<canvas>().transform.Find("HighScore4").transform.Find("Score").transform.Find("Text").GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("HighScore4score", 0).ToString();

        FindObjectOfType<canvas>().transform.Find("HighScore5").transform.Find("Name").transform.Find("Text").GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetString("HighScore5name", "Player 5");
        FindObjectOfType<canvas>().transform.Find("HighScore5").transform.Find("Score").transform.Find("Text").GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("HighScore5score", 0).ToString();
    }

    public void returnButton()
    {
        SceneManager.LoadScene("Menu");
    }
}
