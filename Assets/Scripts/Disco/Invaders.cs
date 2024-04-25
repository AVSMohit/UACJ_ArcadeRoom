
using System.Linq.Expressions;
using System.Security.Cryptography;
using Unity.Collections;
using UnityEngine;

public class Invaders : MonoBehaviour
{
    public Invader[] prefabs;

    public Proectile missilePrefab;

    public int rows;
    public int cols;
    public AnimationCurve speed;

    Vector3 direction = Vector2.right;

    public int amountKilled {  get; private set; }
    public int totalInvaders => this.rows * this.cols;
    public float percentkilled =>(float) this.amountKilled/(float)totalInvaders;
    public int amountAlive => this.totalInvaders - amountKilled;

    public float missileAttackRate = 1f;

    Vector3 initialPosition;
    private void Awake()
    {
        for (int row = 0; row< rows; row++)
        {

            float width = 3 * (this.cols - 1);
            float height = 3 * (this.rows - 1);
            Vector2 centering = new Vector2 (-width/2, -height/2);
            Vector3 rowPosition = new Vector3(centering.x,centering.y + row * 3f,0.0f);

            for(int col = 0; col< cols; col++)
            {
               Invader invedar =  Instantiate(this.prefabs[row], this.transform);
                invedar.killed += InvaderKilled ;
                Vector3 position = rowPosition;
                position.x += col * 3f;
                invedar.transform.localPosition = position;
            }
        }
    }

    private void Update()
    {
        this.transform.position += direction * this.speed.Evaluate(percentkilled) * Time.deltaTime;

        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);

        foreach(Transform invader in this.transform)
        {
            if (!invader.gameObject.activeInHierarchy)
            {
                continue;
            }
            if(direction == Vector3.right && invader.position.x >= (rightEdge.x - 1f))
            {
                AdvanceRow();
            }
            else if(direction == Vector3.left && invader.position.x <= (leftEdge.x + 1f))
            {
                AdvanceRow();
            }
        }
    }

    private void Start()
    {
        //initialPosition = transform.position;
        //NewGame();
        //InvokeRepeating(nameof(MissileAttak),this.missileAttackRate,this.missileAttackRate);
    }
    private void OnEnable()
    {
        initialPosition = transform.position;
        NewGame();
        InvokeRepeating(nameof(MissileAttak), this.missileAttackRate, this.missileAttackRate);
    }
    void NewGame()
    {
        
        amountKilled = 0;
        transform.position = initialPosition;
        foreach (Transform invader in this.transform)
        {
            
            invader.gameObject.SetActive(true);
            
        }

    }

    void MissileAttak()
    {
        foreach(Transform invader in this.transform)
        {
            if (!invader.gameObject.activeInHierarchy)
            {
                continue;
            }

            if (Random.value < (1f / (float)amountAlive))
            {
                Instantiate(this.missilePrefab, invader.position, Quaternion.identity);
                break;
            }
        }
    }

    void AdvanceRow()
    {
        direction.x *= -1f;

        Vector3 position = this.transform.position;
        position.y -= 2f;
        transform.position = position;
    }

    void InvaderKilled()
    {
        amountKilled++;
        if(this.amountKilled >= this.totalInvaders)
        {
            NewGame();
        }
    }
}
