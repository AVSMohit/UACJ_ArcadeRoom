
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Canon : MonoBehaviour
{
    public GameObject prefab;

    public Transform bulletSpawn;

    bool shoot;

    float shootTimer = 5;
    float shootinterval = 5f;

    private void Start()
    {
        
    }

    private void Update()
    {
        shootTimer -= Time.deltaTime;

        if(shootTimer <= 0)
        {
            Shoot();
            shootinterval = 5f * DinoGameManager.instance.gameSpeed;
            shootTimer = shootinterval;
        }
    }
    void Shoot()
    {
        GameObject bullet = Instantiate(prefab,bulletSpawn.position,Quaternion.identity);


    }
    
}
