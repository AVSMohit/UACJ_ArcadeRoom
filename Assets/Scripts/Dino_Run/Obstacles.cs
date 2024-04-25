
using UnityEngine;

public class Obstacles : MonoBehaviour
{

    float leftEdge;

    private void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 3f;
    }
    private void Update()
    {
        transform.position += Vector3.left * DinoGameManager.instance.gameSpeed * Time.deltaTime;

        if(transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }
    }
}
