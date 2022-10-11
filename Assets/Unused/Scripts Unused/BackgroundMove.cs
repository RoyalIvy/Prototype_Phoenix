using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    [SerializeField] private float speed;

    void Update()
    {
        BackMove();
    }

    private void BackMove()
    {
        Vector2 move = new Vector2(speed, 0);

        transform.Translate(-speed * Time.deltaTime * move);
    } // движение заднего фона 
}
