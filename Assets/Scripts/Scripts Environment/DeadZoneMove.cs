using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZoneMove : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private float seconds;

    [Space]

    [SerializeField] private double counterSpeed;

    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        InvokeRepeating(nameof(Boost), 0, seconds);
    }

    private void FixedUpdate()
    {
        this.Move();
    }

    private void Move()
    {
        _rb.AddForce(new Vector2(speed, 0) * speed);
    }

    private void Boost()
    {
        speed += (float)counterSpeed;

        if (speed > 10)
        {
            speed = 10;
        }
    } 
}
