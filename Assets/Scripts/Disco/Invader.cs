
using UnityEngine;

public class Invader : MonoBehaviour
{
    public Sprite[] animationSprite;

    public float animationTIme;

    SpriteRenderer spriteRenderer;

    int animationFrame;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite),animationTIme,animationTIme);
    }

    void AnimateSprite()
    {
        animationFrame++;
        if(animationFrame >= animationSprite.Length)
        {
            animationFrame = 0;
        }

        spriteRenderer.sprite = animationSprite[animationFrame];

    }
}
