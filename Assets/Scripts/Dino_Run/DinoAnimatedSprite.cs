
using UnityEngine;

public class DinoAnimatedSprite : MonoBehaviour
{
    public Sprite[] sprites;

    SpriteRenderer spriteRenderer;
    int frame;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        Invoke(nameof(Animate), 0f);
    }
    private void OnDisable()
    {
        CancelInvoke();
    }
    void Animate()
    {
        frame++;
        if(frame >= sprites.Length)
        {
            frame = 0;
        }

        if( frame >=0 && frame < sprites.Length) 
        {
            spriteRenderer.sprite = sprites[frame];
        }

        Invoke(nameof(Animate),1f/DinoGameManager.instance.gameSpeed);
    }
}

