using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveVertical : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private Transform startPosition;
    [SerializeField] private int distance;

    bool movingRight;

    private void FixedUpdate()
    {

        if (transform.position.y > startPosition.position.y + distance)
        {
            movingRight = false;
        }
        else if (transform.position.y < startPosition.position.y - distance)
        {
            movingRight = true;
        }

        if (movingRight)
        {
            transform.position = new Vector2(transform.position.x,
                transform.position.y + speed * Time.fixedDeltaTime);
        } 
        else
        {
            transform.position = new Vector2(transform.position.x,
                transform.position.y - speed * Time.fixedDeltaTime);
        }
    }
}
