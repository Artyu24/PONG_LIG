using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpeedLimit : MonoBehaviour
{
    public float maxSpeed = 20f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (rb.velocity.magnitude > maxSpeed)
        {
            Debug.Log("ON EST A FOND");
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }
}
