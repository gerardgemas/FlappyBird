using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public static GameManager instance;
    public bool start;
    [SerializeField] private TMPro.TextMeshProUGUI scoreText;
    [SerializeField] private TMPro.TextMeshProUGUI tapText;
    [SerializeField] private TMPro.TextMeshProUGUI lost;
    [SerializeField] private TMPro.TextMeshProUGUI highScoreText;
    private bool restart = false;
    private int highScore;
    // Start is called before the first frame update
    void Start()
    {
        LoadHighScore();
        highScoreText.text = "HighScore: " + highScore.ToString();
        start = false;
    }
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject); // Ensures only one GameManager exists
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && start == false || Input.GetMouseButtonDown(0) && start == false) 
        {
            startGame();
            tapText.gameObject.SetActive(false);
        }
        if(restart && Input.GetMouseButtonDown (0))
        {
            restart = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    public void increaseScore()
    {
        score = score + 1;
    }
    public void endGame()
    {
        GameObject player = GameObject.FindWithTag("Player");
        Player playerScript = player.GetComponent<Player>();
        lost.text = "GameOver!\n" + "Your Socre:" + score.ToString() + "\n Tap to restart!";
        lost.gameObject.SetActive(true);
        
        scoreText.gameObject.SetActive(false);
        restart = true;
        // Set the player's velocity to zero to freeze them in place
        playerScript.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        playerScript.enabled = false; // Disable the Player script to stop further input
        playerScript.FreezeMovement();


        // Disable gravity on the player's Rigidbody2D
        playerScript.GetComponent<Rigidbody2D>().gravityScale = 0f;
        

        // Stop the pipes movement
        GameObject[] pipes = GameObject.FindGameObjectsWithTag("Pipe");
        foreach (GameObject pipe in pipes)
        {
           pipe.GetComponent<Tub>().enabled = false;
        }
        GameObject.FindWithTag("SpawnManager").GetComponent<Spawner>().setSpawnable(false);

        // Stop the background movement
        GameObject.FindWithTag("Background1").GetComponent<BackgroundLooper>().StopScrolling();
        GameObject.FindWithTag("Background").GetComponent<BackgroundLooper>().StopScrolling();

        start = false;
        if (score > highScore)
        {
            highScore = score;
            SaveHighScore();
            
        }

    }
    public void updateScore()
    {
        scoreText.text = score.ToString();
    }
    public void startGame()
    {
        start = true;
    }
    private void LoadHighScore()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    private void SaveHighScore()
    {
        PlayerPrefs.SetInt("HighScore", highScore);
        PlayerPrefs.Save();
    }

    public int GetHighScore()
    {
        return highScore;
    }
}
