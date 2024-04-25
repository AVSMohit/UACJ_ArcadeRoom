
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.HableCurve;

public class PenguinEmperor : MonoBehaviour
{
    Vector2 _direction;

    Rigidbody2D _body;
    public float speed = 0.4f;

    List<Transform> _segments;

    public Transform segementprefab;
    private void Start()
    {
        Time.fixedDeltaTime = 0.1f;
        _direction = Vector2.right;
        _segments = new List<Transform>();
        _segments.Add(this.transform);


    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && _direction != Vector2.down)
        {
            _direction = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.S) && _direction != Vector2.up)
        {
            _direction = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.D) && _direction != Vector2.left)
        {
            _direction = Vector2.right;
        }
        else if (Input.GetKeyDown(KeyCode.A) && _direction != Vector2.right)
        {
            _direction = Vector2.left;
        }
    }

    private void FixedUpdate()
    {
        //Vector3 previousPosition = transform.position;

        //for (int i = _segments.Count - 1; i > 0; i--)
        //{
        //    // Move each segment slightly behind the segment in front of it

        //    _segments[i].position = _segments[i - 1].position;

        //    // Rotate each segment to align with the direction towards the previous segment
        //    // _segments[i].rotation = Quaternion.LookRotation(Vector3.forward, (_segments[i - 1].position - _segments[i].position).normalized);
        //}
        // previousPosition = transform.position +  (Vector3)_direction * speed * Time.fixedDeltaTime;

        //transform.position = previousPosition;
        //// Rotate head
        //transform.rotation = Quaternion.LookRotation(Vector3.forward, _direction);
        for (int i = _segments.Count - 1; i > 0; i--)
        {
            _segments[i].position = _segments[i - 1].position;
           
           // _segments[i].rotation = Quaternion.LookRotation(Vector3.forward, _direction);
        }

        this.transform.position = new Vector3(Mathf.Round(this.transform.position.x + _direction.x), Mathf.Round(this.transform.position.y + _direction.y), 0.0f);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, _direction);
        for (int i = _segments.Count - 1; i > 0; i--)
        {
           // _segments[i].position = _segments[i - 1].position;
            _segments[i].rotation = Quaternion.LookRotation(Vector3.forward, _direction);
        }
    }

    void Grow()
    {
        Transform segment = Instantiate(segementprefab);
        segment.position = _segments[_segments.Count - 1].position;
        _segments.Add(segment);
    }

    void ResetState()
    {
        for(int i =1; i < _segments.Count; i++)
        {
            Destroy(_segments[i].gameObject);
        }
        _segments.Clear();
        _segments.Add(this.transform);

        this.transform.position = Vector3.zero;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Food"))
        {
            Grow();
          
           
        }
        else if (collision.gameObject.CompareTag("Wall"))
        {
            ResetState();
        }
    }

    

}
