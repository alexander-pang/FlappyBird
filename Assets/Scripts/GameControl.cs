using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public static GameControl instance;
    public GameObject gameOverText;
    public bool gameOver = false;
    public float scrollSpeed = -1.5f;
    public Text scoreText;

    private int score = 0;

    //Bird 2 stuff
    public Text scoreText2;
    public bool isTwoBirdGame = false;
    private int scoreTwo = 0;
    public int birdsDead  = 0;


    // Start is called before the first frame update
    void Awake()
    {
        if(MainMenu.isTwoPlayerGame == true)
        {
            isTwoBirdGame = true;
        }
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOver == true && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void BirdScored()
    {
        if (gameOver)
        {
            return;
        }
        score++;
        scoreText.text = "Score: " + score.ToString();
    }

    public void Bird2Scored()
    {
        if (gameOver)
        {
            return;
        }
        scoreTwo++;
        scoreText2.text = "Blue Score: " + score.ToString();
    }

    public void BirdDied()
    {
        gameOverText.SetActive(true);
        gameOver = true;
    }
    public void OneBirdDied()
    {
        birdsDead++;
        if (birdsDead == 2)
        {
            gameOverText.SetActive(true);
            gameOver = true;
        }
    }
}
