using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public static GameControl instance;
    public GameObject gameOverText;
    public bool gameOver = false;
    public float scrollSpeed;
    public Text scoreText;

    public GameObject highScoreUI;
    public float speedVariance = 1;

    public int score = 0;

    //Bird 2 stuff
    public Text scoreText2;
    public bool isTwoBirdGame = false;
    private int scoreTwo = 0;
    public int birdsDead = 0;

    private bool settingHighScore = false;


    // Start is called before the first frame update
    void Awake()
    {
        scrollSpeed = -1.5f;
        speedVariance = 1f;
        if (MainMenu.isTwoPlayerGame == true)
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
        if (HighScoreManager.instance.isAHighScore(score) && settingHighScore == false && gameOver && SceneManager.GetActiveScene().name == "2Birds")
        {
            highScoreUI.SetActive(true);
            settingHighScore = true;
        }

        else if (gameOver == true && Input.GetMouseButtonDown(0) && settingHighScore == false)
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
        if (speedVariance < 2.5f)
        {
            speedVariance = speedVariance + .25f;
            FindObjectOfType<ColumnPool>().spawnRate = FindObjectOfType<ColumnPool>().spawnRate - .4f;
        }
        
        scoreText.text = "Score: " + score.ToString();
    }

    public void Bird2Scored()
    {
        if (gameOver)
        {
            return;
        }
        if(birdsDead == 1 && speedVariance < 2.5f)
        {
            speedVariance = speedVariance + .25f;
            FindObjectOfType<ColumnPool>().spawnRate = FindObjectOfType<ColumnPool>().spawnRate - .4f;
        }

        scoreTwo++;
        scoreText2.text = "Blue Score: " + scoreTwo.ToString();
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
