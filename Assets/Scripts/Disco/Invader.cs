
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Invader : MonoBehaviour
{
    public Sprite[] animationSprite;

    public float animationTIme;

    SpriteRenderer spriteRenderer;

    int animationFrame;

    public System.Action killed;

    public float score;

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Laser"))
        {
            this.gameObject.SetActive(false);
            DiscoGameManager.instance.UpdateScore(score);
            this.killed.Invoke();
        }
    }
}
