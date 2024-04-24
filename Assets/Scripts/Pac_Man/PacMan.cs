
using UnityEngine;

[RequireComponent (typeof(GenericMovement))]
public class PacMan : MonoBehaviour
{
    public GenericMovement genericMovement {  get; private set; }

    private void Awake()
    {
        this.genericMovement = GetComponent<GenericMovement>(); 
    }
    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) 
        {
            this.genericMovement.SetDirection(Vector2.up);
        }
        if(Input.GetKeyUp(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) 
        {
            this.genericMovement.SetDirection(Vector2.down);
        }
        if(Input.GetKeyUp(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) 
        {
            this.genericMovement.SetDirection(Vector2.left);
        }
        if(Input.GetKeyUp(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) 
        {
            this.genericMovement.SetDirection(Vector2.right);
        }

        float angle = Mathf.Atan2(this.genericMovement.direction.y, this.genericMovement.direction.x);

        this.transform.rotation = Quaternion.AngleAxis(angle * Mathf.Rad2Deg, Vector3.forward);
    }

    public void ResetState()
    {
        this.genericMovement.ReserState();
        this.gameObject.SetActive(true);

    }
}
