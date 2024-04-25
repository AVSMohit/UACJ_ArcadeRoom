using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Ghosts[] ghosts;
    public PacMan pacMan;
    public Transform pellets;

    public int score { get; private set; }
    int highscore;
    public int lives { get; private set; }

    public GameObject gameOverPanel;
    public GameObject StartGamePanel;


    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI HighScoreText;
    public int ghostMultiplier { get; private set; } = 1;
    private void Start()
    {
        StartGamePanel.SetActive(true);
        gameOverPanel.SetActive(false);
     //   NewGame();   
    }

    void StartGame()
    {
        StartGamePanel.SetActive(false);
        NewRound();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && StartGamePanel.activeInHierarchy)
        { 
            StartGame();
        }

        if (Input.GetKeyDown(KeyCode.R) && this.lives <= 0)
        {
            NewGame();
        }if (Input.GetKeyDown(KeyCode.Escape) && this.lives <= 0)
        {

            SceneManager.LoadScene(0, LoadSceneMode.Single);
        }
        scoreText.text = Mathf.FloorToInt(score).ToString("D5");
    }
    void NewGame()
    {
        SetScore(0);
        SetLives(3);
        NewRound();
       
        SceneManager.LoadScene(SceneManager.GetActiveScene().name,LoadSceneMode.Single);
    }

    void NewRound()
    {
        foreach(Transform pellet in this.pellets)
        {
            pellet.gameObject.SetActive(true);
        }
        gameOverPanel.SetActive(false);
        ResetState();
    }

    void ResetState()
    {
        ResetGhostMutliplier();
        for (int i = 0; i < this.ghosts.Length; i++)
        {
            this.ghosts[i].ResetState();
        }

        this.pacMan.ResetState();
    }

    void GameOver()
    {
        for (int i = 0; i < this.ghosts.Length; i++)
        {
            this.ghosts[i].gameObject.SetActive(false);
        }
        gameOverPanel.SetActive(true);
        this.pacMan.gameObject.SetActive(false);
    }
    void SetScore(int score)
    {
        this.score = score;
    }

    void SetLives(int lives)
    {
        this.lives = lives;
    }


    public void GhostConsumed(Ghosts ghosts)
    {
        int points = ghosts.points * this.ghostMultiplier;

        SetScore(this.score + points);
        this.ghostMultiplier++;
    }

    public  void PacManEaten()
    {
        this.pacMan.gameObject.SetActive(false);
        SetLives(this.lives - 1);
        if(this.lives > 0)
        {
            Invoke(nameof(ResetState),3.0f);
        }
        else 
        { 
            GameOver();
        }
    }

    public void PelletEaten(Pellet pellet)
    {
        pellet.gameObject.SetActive(false);
        SetScore(pellet.points  + this.score);
        if (!HasRemainingPellets())
        {
            this.pacMan.gameObject.SetActive(false);
            Invoke(nameof(NewRound), 3.0f);
        }
    }
    public void PowerPelletEaten(PowerPellet pellet)
    {

        for(int i = 0; i < this.ghosts.Length; i++)
        {

            this.ghosts[i].frightened.Enable(pellet.duration);
        }
        PelletEaten(pellet);
        CancelInvoke();
        Invoke(nameof(ResetGhostMutliplier), pellet.duration);

    }

    private bool HasRemainingPellets()
    {
        foreach (Transform pellet in this.pellets)
        {
           if(pellet.gameObject.activeSelf)
            {
                return true;
            }
        }
        return false;

    }

    private void ResetGhostMutliplier()
    {
        this.ghostMultiplier = 1;
    }
    void UpdateHighScore()
    {
        float highScore = PlayerPrefs.GetFloat("PuckyHighScore", 0);

        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetFloat("PuckyHighScore", highScore);
        }
        HighScoreText.text = Mathf.FloorToInt(highScore).ToString("D5");
    }
}
