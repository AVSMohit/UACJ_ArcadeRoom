
using UnityEngine;

public class Dino : MonoBehaviour
{
    public CharacterController characterController{  get; private set; }

    Vector3 direction;

    public float gravity = 9.8f * 2;
    public float jumpForce = 8;
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }


    private void OnEnable()
    {
        direction = Vector3.zero;
    }

    private void Update()
    {
        direction += Vector3.down * gravity * Time.deltaTime;

        if (characterController.isGrounded)
        {
            direction = Vector3.down;

            if(Input.GetKeyDown(KeyCode.Space))
            {
                direction = Vector3.up * jumpForce;
            }
        }
        characterController.Move(direction * Time.deltaTime);
    }

}
