
using UnityEngine;

public class Fence : MonoBehaviour
{
    MeshRenderer fence;

    private void Awake()
    {
        fence = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        float speed = DinoGameManager.instance.gameSpeed / transform.localScale.x;
        fence.material.mainTextureOffset += Vector2.right * speed * Time.deltaTime;
    }
}
