
using UnityEngine;

[RequireComponent (typeof(Ghosts))]
public abstract class Ghostbehavior : MonoBehaviour
{
    public Ghosts ghost { get; private set; }

    public float duration;

    private void Awake()
    {
        this.ghost = gameObject.GetComponent<Ghosts>();
        this.enabled = false;
    }

    public void Enable()
    {
        Enable(duration);
    }
    
    public virtual void Enable(float duration)
    {
        this.enabled = true;
        CancelInvoke();
        Invoke(nameof(Disable), duration);
    }

    public virtual void Disable()
    {
        this.enabled = false;
        CancelInvoke();

    }



}
