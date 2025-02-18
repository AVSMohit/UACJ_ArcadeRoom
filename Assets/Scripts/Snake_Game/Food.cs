
using UnityEngine;

public class Food : MonoBehaviour
{
    public BoxCollider2D gridArea;


    private void Start()
    {
        RandomisePosition();
    }

    void RandomisePosition()
    {
        Bounds bounds= this.gridArea.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        this.transform.position = new Vector3(Mathf.Round(x),Mathf.Round(y),0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
          RandomisePosition();

        }
    }
}
