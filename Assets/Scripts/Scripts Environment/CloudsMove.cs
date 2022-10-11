using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudsMove : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float seconds;

    [Space] 

    [SerializeField] private double counterSpeed;

    [Space] 

    [SerializeField] private GameObject boostBox;

    private void Start()
    {
        InvokeRepeating(nameof(Boost), 0, seconds); // постоянный повтор вызова метода Boost()
    }

    private void Update()
    {
        MoveClouds();
    } 

    private void MoveClouds()
    {
        Vector2 move = new Vector2(speed, 0);

        transform.Translate(speed * Time.deltaTime * move);
    } // движение облаков

    private void Boost()
    {
        speed += (float)counterSpeed;

        if (speed > 8)
        {
            speed = 8;
        }
    } // плавное ускорение
}
