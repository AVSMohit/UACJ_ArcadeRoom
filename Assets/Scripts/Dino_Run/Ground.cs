
using UnityEngine;

public class Ground : MonoBehaviour
{
    
    MeshRenderer ground;

    private void Awake()
    {
        ground = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        float speed = DinoGameManager.instance.gameSpeed / transform.localScale.x;
        ground.material.mainTextureOffset += Vector2.right * speed * Time.deltaTime;
    }
}
