using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    [SerializeField] float speed = 11;
    Vector2 horizontalInput;
    public static Vector3 preiousPosition ;

    private void Start()
    {
        Time.fixedDeltaTime = 0.02f;
        transform.position = preiousPosition;
    }
    private void Update()
    {
        preiousPosition = transform.position;
        Vector3 horizontalVelocity = (transform.right * horizontalInput.x + transform.forward * horizontalInput.y) * speed;
        controller.Move(horizontalVelocity * Time.deltaTime);
    }
    public void RecieveInput(Vector2 _horizontalInput)
    {
        horizontalInput = _horizontalInput;
        print(horizontalInput);
    }
    
}
