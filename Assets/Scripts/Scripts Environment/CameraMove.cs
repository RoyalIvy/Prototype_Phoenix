using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float offsetX;
    [SerializeField] private float offsetY;

    Vector3 pos;
    private Vector3 velocity = Vector3.zero;

    [SerializeField] private float smoothTime; // жесткость привязки камеры при движении персонажа

    private void Update()
    {
        if(player)
        {
            pos = new Vector3(player.transform.position.x + offsetX,
                player.transform.position.y + offsetY,
                transform.position.z);

            transform.position = Vector3.SmoothDamp(transform.position, pos, ref velocity, smoothTime);
        }
    }
}
