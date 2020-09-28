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

    private int indexOfColumn;


    // Start is called before the first frame update
    void Awake()
    {
        scrollSpeed = -1.5f;
        speedVariance = 1f;
        indexOfColumn = 0;
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
        if(SceneManager.GetActiveScene().name == "Main")
        {

            Bird bird = FindObjectOfType<Bird>();

            BoxCollider2D collider = FindObjectOfType<ColumnPool>().columns[indexOfColumn].GetComponent<BoxCollider2D>();
            GameObject du = FindObjectOfType<ColumnPool>().columns[indexOfColumn].gameObject;

            float yUpper =  collider.bounds.center.y + collider.bounds.extents.y;
            float yLower = collider.bounds.center.y - collider.bounds.extents.y;

            UnityEngine.Debug.Log(indexOfColumn);

            if (bird.transform.position.y < yUpper && bird.transform.position.y > yLower)
            {
                UnityEngine.Debug.LogError("HI");
                FindObjectOfType<AudioManager>().PlayIfNotPlaying("SoundAlert");
            }
            else
            {
                FindObjectOfType<AudioManager>().Stop("SoundAlert");
            }
            
        }
        if (HighScoreManager.instance.isAHighScore(score) && settingHighScore == false && gameOver && SceneManager.GetActiveScene().name == "main")
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

        if (indexOfColumn == 4)
        {
            indexOfColumn = 0;
        }
        else
        {
            indexOfColumn++;
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
