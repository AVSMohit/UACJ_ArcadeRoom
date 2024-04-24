
using UnityEngine;

public class Ghosts : MonoBehaviour
{

    public GenericMovement genericMovement {  get; private set; }

    public GhostsHome home { get; private set; }
    public GhostsScatter scatter { get; private set; }
    public GhostsChase chase { get; private set; }
    public GhotsFrightened frightened { get; private set; }

    public Ghostbehavior initialbehavior;

    public Transform target;
   
    public int points = 200;

    private void Awake()
    {
        this.genericMovement = GetComponent<GenericMovement>();
        this.home = GetComponent<GhostsHome>();
        this.chase = GetComponent<GhostsChase>();
        this.frightened = GetComponent<GhotsFrightened>();
        this.scatter = GetComponent<GhostsScatter>();
    }

    private void Start()
    {
        ResetState();
    }

    public void ResetState()
    {
        this.gameObject.SetActive(true);
        this.genericMovement.ReserState();

        this.frightened.Disable();
        this.chase.Disable();
        this.scatter.Enable();
        
        if(this.home != this.initialbehavior)
        {
            this.home.Disable();
        }

        if(this.initialbehavior != null)
        {
            this.initialbehavior.Enable();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("PacMan")) 
        {
            if (this.frightened.enabled)
            {
                FindObjectOfType<GameManager>().GhostConsumed(this);
            }
            else
            {
                FindObjectOfType<GameManager>().PacManEaten();
            }

        }
    }
}
