using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5;

    private PlayerMotor motor;

    void Start()
    {
        motor = GetComponent<PlayerMotor>();
    }

    void Update()
    {
        float yMov = Input.GetAxisRaw("Vertical");
        Vector2 moveVertical = transform.up * yMov;
        Vector2 velocity = moveVertical.normalized * speed;

        motor.Move(velocity);
    }
}
