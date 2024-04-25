using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonBullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void Update()
    {
        transform.position += Vector3.left * DinoGameManager.instance.gameSpeed * Time.deltaTime;
    }

}
