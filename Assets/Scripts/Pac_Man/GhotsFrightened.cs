
using UnityEngine;

public class GhotsFrightened : Ghostbehavior
{
    public SpriteRenderer body;

    public SpriteRenderer eyes;

    public SpriteRenderer blue;

    public SpriteRenderer flash;

    public bool eaten {  get; private set; }


    public override void Enable(float duration)
    {
        base.Enable(duration);
        this.body.enabled = false;
        this.eyes.enabled = false;
        this.blue.enabled = true;
        this.flash.enabled = false;

        Invoke(nameof(Flash),duration/2.0f);
    }

    public override void Disable()
    {
        base.Disable();
        this.body.enabled = true;
        this.eyes.enabled = true;
        this.blue.enabled = false;
        this.flash.enabled = false;
    }
    private void Flash()
    {
        if (!this.eaten)
        {
            this.blue.enabled = false;
            this.flash.enabled = true;
            this.flash.GetComponent<AnimatedSprite>().RestartAnimation();
        }
        
    }
    void Eaten()
    {
        eaten = true;

        Vector3 position = this.ghost.home.inside.position;
        position.z = this.ghost.home.inside.position.z;
        this.ghost.transform.position = position;

        this.ghost.home.Enable(this.duration);
        this.body.enabled = false;
        this.eyes.enabled = true;
        this.blue.enabled = false;
        this.flash.enabled = false;

    }
    private void OnEnable()
    {
        this.ghost.genericMovement.speedMultiplier = 0.5f;
        this.eaten = false; 
    }

    private void OnDisable()
    {
        this.ghost.genericMovement.speedMultiplier = 1f;
        this.eaten = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("PacMan"))
        {
            if (this.enabled)
            {
                Eaten();
            }
         

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Node node = collision.GetComponent<Node>();

        if (node != null && this.enabled )
        {
            Vector2 direction = Vector2.zero;
            float maxDistance = float.MinValue;

            foreach (Vector2 availableDirection in node.availableDirections)
            {
                Vector3 newPosition = this.transform.position + new Vector3(availableDirection.x, availableDirection.y, 0.0f);
                float distance = (this.ghost.target.position - newPosition).sqrMagnitude;

                if (distance > maxDistance)
                {
                    direction = availableDirection;
                    maxDistance = distance;
                }
            }
            this.ghost.genericMovement.SetDirection(direction);
        }
    }
}
