using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] Movement movement;
    [SerializeField] Mouse_look mouseLook;

    Vector2 mouseInput;

    PLayerInputs inputs;
    PLayerInputs.GroundMovementActions groundMovement;

    Vector2 horizontalMovement;

    private void Awake()
    {
        inputs = new PLayerInputs();
        groundMovement =  inputs.GroundMovement;

        groundMovement.HorizontalMovement.performed += ctx => horizontalMovement = ctx.ReadValue<Vector2>();
        groundMovement.MouseX.performed += ctx => mouseInput.x = ctx.ReadValue<float>();
        groundMovement.MouseY.performed += ctx => mouseInput.y = ctx.ReadValue<float>();
    }

    private void OnEnable()
    {
        inputs.Enable();
    }

    private void OnDisable()
    {
       inputs.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement.RecieveInput(horizontalMovement);
        mouseLook.RecieveInput(mouseInput);
    }
}
