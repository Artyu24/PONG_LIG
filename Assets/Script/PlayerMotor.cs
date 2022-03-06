using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMotor : MonoBehaviour
{
    private Vector2 velocity;
    private float scroll;
    private Rigidbody2D rb;
    private Vector3 refVelocity = Vector3.zero;
    public float movSpeed = 50;
    public float scrollSpeed = 10;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Move(Vector2 _velocity)
    {
        velocity = _velocity;
    }

    private void Update()
    {
        scroll = Input.GetAxis("Mouse ScrollWheel");
        //Debug.Log(scroll);
        PerformRotation();
    }

    private void FixedUpdate()
    {
        PerformMovement();
    }

    private void PerformMovement()
    {
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime * movSpeed);
    }
    
    private void PerformRotation()
    {
        if (scroll != 0)
        {
            transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z + (scroll * scrollSpeed * Time.fixedDeltaTime));
        }
    }
}
