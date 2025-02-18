
using UnityEngine;

public class GhostsScatter : Ghostbehavior
{
    private void OnDisable()
    {
        this.ghost.chase.Enable();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Node node = collision.GetComponent<Node>();

        if(node != null && this.enabled && !this.ghost.frightened.enabled)
        {
            int index = Random.Range(0, node.availableDirections.Count);
            if (node.availableDirections[index] == -this.ghost.genericMovement.direction && node.availableDirections.Count > 1)
            {
                index++;
                if(index >= node.availableDirections.Count)
                {
                    index = 0;
                }
            }
            this.ghost.genericMovement.SetDirection(node.availableDirections[index]);
        }
    }

}
