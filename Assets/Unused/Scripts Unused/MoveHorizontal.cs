using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHorizontal : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private int speed;

    [SerializeField] private Transform startPosition;
    [SerializeField] private int distance;

    bool movingRight;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {

        if (transform.position.x > startPosition.position.x + distance)
        {
            movingRight = false;
        }
        else if (transform.position.x < startPosition.position.x - distance)
        {
            movingRight = true;
        }

        if (movingRight)
        {
            transform.position = new Vector2(transform.position.x 
                + speed * Time.fixedDeltaTime,
                transform.position.y);
        } 
        else
        {
            transform.position = new Vector2(transform.position.x
                - speed * Time.fixedDeltaTime,
                transform.position.y);
        }
    }
}
