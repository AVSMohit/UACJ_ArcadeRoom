
using System.Security.Cryptography;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class DinoGameManager : MonoBehaviour
{
    public static DinoGameManager instance {  get; private set; }

    public float gameSpeed { get; private set; }

    public float initialGameSpeed = 5f;

    public float gameSpeedIncreas = 0.1f;


    [SerializeField] Dino player;
    [SerializeField]Spawner spawner;

    public bool gameOver = true;

    public TextMeshProUGUI GameOverText;
    public TextMeshProUGUI StartGameText;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI HighScoreText;

    float score;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            DestroyImmediate(gameObject);
        }

    }
    // Start is called before the first frame update
    private void OnDestroy()
    {
        if(instance == this)
        {
            instance = null;
        }
    }

    private void Start()
    {
        player = FindObjectOfType<Dino>();
        spawner = FindObjectOfType<Spawner>();
        GameOverText.gameObject.SetActive(false);
        StartGameText.gameObject.SetActive(true);
        //gameSpeed = initialGameSpeed;
        // NewGame();

    }
    private void Update()
    {
       
            gameSpeed += gameSpeedIncreas * Time.deltaTime;

        if (!gameOver)
        {

            score += gameSpeed * Time.deltaTime;
            ScoreText.text = Mathf.FloorToInt(score).ToString("D5");
        }
      

        
        if(Input.GetKeyDown(KeyCode.R) && gameOver)
        {
            NewGame();
        } 
        if(Input.GetKeyDown(KeyCode.Escape) && gameOver)
        {
            SceneManager.LoadScene(0, LoadSceneMode.Single);
        }
        if(Input.GetKeyDown(KeyCode.Space) && gameOver)
        {
            NewGame();
        }
    }
    void NewGame()
    {
        StartGameText.gameObject.SetActive(false);
        score = 0;
        gameOver = false;
        Obstacles[] obstacles = FindObjectsOfType<Obstacles>();
        foreach(var obstacle in obstacles)
        {
            Destroy(obstacle.gameObject);
        }
        gameSpeed = initialGameSpeed;
        // enabled = true;
        GameOverText.gameObject.SetActive(false);
        player.gameObject.SetActive(true);
        spawner.gameObject.SetActive(true);
        gameSpeedIncreas = .1f;
        UpdateHighScore();
    }

    public void GameOver()
    {
        gameOver = true;
        GameOverText.gameObject.SetActive(true);
        gameSpeed = 0;
        // enabled = false;
        gameSpeedIncreas = 0f;
        player.gameObject.SetActive(false);
        spawner.gameObject.SetActive(false);
        UpdateHighScore();
    }

    void UpdateHighScore()
    {
        float highScore = PlayerPrefs.GetFloat("DinoHighScore", 0);

        if(score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetFloat("DinoHighScore", highScore);
        }
        HighScoreText.text = Mathf.FloorToInt(highScore).ToString("D5");
    }

}
