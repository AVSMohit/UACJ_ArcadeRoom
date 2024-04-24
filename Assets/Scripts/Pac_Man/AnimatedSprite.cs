
using UnityEngine;

[RequireComponent (typeof(SpriteRenderer))]
public class AnimatedSprite : MonoBehaviour
{
    public SpriteRenderer spriteRenderer { get; private set; }

    public Sprite[] sprites;

    public float animationTime = 0.25f;

    public int animationFrame {  get; private set; }

    public bool loop = true;
    private void Awake()
    {
       this.spriteRenderer = GetComponent<SpriteRenderer> ();
    }

    private void Start()
    {
        InvokeRepeating(nameof(Advance),animationTime,animationTime);
    }

    void Advance()
    {
        if(!this.spriteRenderer.enabled)
        {
            return;
        }
        this.animationFrame++;

        if(animationFrame >= this.sprites.Length && this.loop)
        {
            this.animationFrame = 0;
        }

        if(this.animationFrame <  this.sprites.Length && this.loop && this.animationFrame >= 0)
        {
            spriteRenderer.sprite = this.sprites[this.animationFrame];
        }
    }


    void RestartAnimation()
    {
        animationFrame = -1;
        Advance();
    }
}
