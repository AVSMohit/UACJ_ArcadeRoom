
using System.Security.Cryptography;
using UnityEngine;

public class DinoGameManager : MonoBehaviour
{
    public static DinoGameManager instance {  get; private set; }

    public float gameSpeed { get; private set; }

    public float initialGameSpeed = 5f;

    public float gameSpeedIncreas = 0.1f;

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
        NewGame();

    }
    private void Update()
    {
        gameSpeed += gameSpeedIncreas * Time.deltaTime;
    }
    void NewGame()
    {
        gameSpeed = initialGameSpeed;
    }



}
