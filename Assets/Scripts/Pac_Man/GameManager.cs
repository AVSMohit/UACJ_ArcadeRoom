using System.Security.Cryptography;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Ghosts[] ghosts;
    public PacMan pacMan;
    public Transform pellets;

    public int score { get; private set; }
    public int lives { get; private set; }


    public int ghostMultiplier { get; private set; } = 1;
    private void Start()
    {
        NewGame();   
    }
    private void Update()
    {
        if (Input.anyKeyDown && this.lives <= 0)
        {
            NewGame();
        }
    }
    void NewGame()
    {
        SetScore(0);
        SetLives(3);
        NewRound();
    }

    void NewRound()
    {
        foreach(Transform pellet in this.pellets)
        {
            pellet.gameObject.SetActive(true);
        }

        ResetState();
    }

    void ResetState()
    {
        ResetGhostMutliplier();
        for (int i = 0; i < this.ghosts.Length; i++)
        {
            this.ghosts[i].gameObject.SetActive(true);
        }

        this.pacMan.gameObject.SetActive(true);
    }

    void GameOver()
    {
        for (int i = 0; i < this.ghosts.Length; i++)
        {
            this.ghosts[i].gameObject.SetActive(false);
        }

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

        //ToDo Change ghost State
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
}
