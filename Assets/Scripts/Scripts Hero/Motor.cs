using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motor : MonoBehaviour 
{
    [SerializeField] private float speed;
    [SerializeField] private float speedV;
    [SerializeField] private float slowDown;

    [Space]

    [SerializeField] private float countDown;
    [SerializeField] private float boost;
    [SerializeField] private float seconds;

    [Space]

    [SerializeField] private double counterSpeed;
    [SerializeField] private double counterSlowDown;

    [Space]

    [SerializeField] private Joystick joystick;

    private float timer;

    private Rigidbody2D _rb;
    private CapsuleCollider2D _col;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _col = GetComponent<CapsuleCollider2D>();

        InvokeRepeating(nameof(Boost), 0, seconds);
    }

    private void FixedUpdate()
    {
        this.Move();
    }

    private void Move()
    {
        _rb.AddForce(new Vector2(speed, 0) * speed);

        if (joystick.Vertical > 0)
        {
            _rb.AddForce(new Vector2(0, speedV) * speed);
        }

        if (joystick.Vertical < 0)
        {
            _rb.AddForce(new Vector2(0, -speedV) * speed);
        }
    } // движение джойстиком

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Cloud"))
        {
            Time.timeScale = 0.5f;
        }
    } // замедление движения

    private void OnTriggerExit2D(Collider2D other)
    {
        Time.timeScale = 1f;
    } // нормальная скорость

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("QuestRedItem"))
        {
            Destroy(other.gameObject);

            for (timer = 0; timer < countDown; timer++)
            {
                Time.timeScale = 1.3f;
            }
        }
    } // ускорение при поднятии буста 
    
    private void Boost()
    {
        speed += (float)counterSpeed;

        if (speed > 10)
        {
            speed = 10;
        }

        slowDown += (float)counterSlowDown;

        if (slowDown > 11)
        {
            slowDown = 11;
        }
    } // постепенное ускорение
    
}
