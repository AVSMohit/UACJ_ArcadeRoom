
using UnityEngine;

public class DiscoPlayer : MonoBehaviour
{
    public float speed = 5.0f;

    public Proectile[] laserPrefab;

    bool laserActive;

    int lives = 3;

    private void Update()
    {
        
        if(Input.GetKey(KeyCode.A) || Input.GetKey((KeyCode.LeftArrow)))
        {
            this.transform.position += Vector3.left * speed * Time.deltaTime;
        } else if(Input.GetKey(KeyCode.D) || Input.GetKey((KeyCode.RightArrow)))
        {
            this.transform.position += Vector3.right * speed * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if ((!laserActive))
        {
            int i = Random.Range(0, laserPrefab.Length);
           Proectile proectile = Instantiate(this.laserPrefab[i], this.transform.position, Quaternion.identity);
            proectile.destroyed += LaserDestroyed;
            laserActive = true; 
        }
    }

    void LaserDestroyed()
    {
        laserActive = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Invader"))
        {

        }
        if(collision.gameObject.layer == LayerMask.NameToLayer("Missile"))
        {
            lives--;
            DiscoGameManager.instance.UpdateLives(lives);
           if(lives <= 0)
            {
                DiscoGameManager.instance.GameOver();
            }
        }
    }
}
