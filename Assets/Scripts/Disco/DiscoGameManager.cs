using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DiscoGameManager : MonoBehaviour
{
    public static DiscoGameManager instance;

    public float score;

    public TextMeshProUGUI scoreText;

    public GameObject GameOverPanel;

    public GameObject startScreen;

    public DiscoPlayer discoPlayer;

    public Invaders invaders;

    public GameObject[] liveSprites;

    
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

    private void Start()
    {
        discoPlayer.enabled = false;
        invaders.enabled = false;
    }

    void StartGame()
    {
        startScreen.gameObject.SetActive(false);
        discoPlayer.enabled = true;
        invaders.enabled = true;
        UpdateLives(3);

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && startScreen.gameObject.activeInHierarchy)
        {
            StartGame();
        }else if (Input.GetKeyDown(KeyCode.R) && GameOverPanel.gameObject.activeInHierarchy || Input.GetKeyDown(KeyCode.R) && startScreen.gameObject.activeInHierarchy)
        {
            SceneManager.LoadScene("Space_Invader", LoadSceneMode.Single);
        }else if (Input.GetKeyDown(KeyCode.Escape) && GameOverPanel.gameObject.activeInHierarchy || Input.GetKeyDown(KeyCode.Escape) && startScreen.gameObject.activeInHierarchy)
        {
            SceneManager.LoadScene(0, LoadSceneMode.Single);
        }
    }
    public void UpdateScore(float points)
    {
        
        score = score + points;
        scoreText.text = Mathf.FloorToInt(score).ToString("d5");
    }

    public void GameOver()
    {
        GameOverPanel.gameObject.SetActive(true);
        discoPlayer.enabled = false;
        invaders.enabled = false;
    }

    public void UpdateLives(int lives)
    {
        for(int i = 0;i <liveSprites.Length;i++)
        {
            liveSprites[i].gameObject.SetActive(false);
        }

        for (int i = 0;i < lives; i++)
        {
            liveSprites[i].gameObject.SetActive(true);
        }
    }
}

