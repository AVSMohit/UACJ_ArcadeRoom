
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class GhostsHome : Ghostbehavior
{
    public Transform inside;
    public Transform outside;


    private void OnEnable()
    {
        StopAllCoroutines();
    }
    private void OnDisable()
    {
        if (this.gameObject.activeSelf)
        {
            StartCoroutine(ExitTransition());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(this.enabled &&  collision.gameObject.layer == LayerMask.NameToLayer("Obstacles"))
        {
            this.ghost.genericMovement.SetDirection(-this.ghost.genericMovement.direction);
        }
    }
    IEnumerator ExitTransition()
    {
        this.ghost.genericMovement.SetDirection(Vector2.up, true);
        this.ghost.genericMovement.rigidbody.isKinematic = true;
        this.ghost.genericMovement.enabled = false;

        Vector3 position = this.transform.position;

        float duration = 0.5f;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            Vector3 newPosition = Vector3.Lerp(position,this.inside.position,elapsed/duration);
            newPosition.z = position.z;
            this.ghost.transform.position = newPosition;

            elapsed += Time.deltaTime;
            yield return null;
        }

         elapsed = 0f;

        while (elapsed < duration)
        {
            Vector3 newPosition = Vector3.Lerp(this.inside.position,this.outside.position,elapsed/duration);
            newPosition.z = position.z;
            this.ghost.transform.position = newPosition;

            elapsed += Time.deltaTime;
            yield return null;
        }

        this.ghost.genericMovement.SetDirection(new Vector2(Random.value < 0.5f ? -1.0f : 1.0f ,0.0f),true);
        this.ghost.genericMovement.rigidbody.isKinematic = false;
        this.ghost.genericMovement.enabled = true;
    }
}
