using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jumps : Hero
{

    [SerializeField] private float jumpForce;
    [SerializeField] private int airJumpCount;
    [SerializeField] private int maxJumps;

    private CapsuleCollider2D _col;
    private Rigidbody2D _rb;

    private void Start()
    {
        airJumpCount = 0;

        _rb = GetComponent<Rigidbody2D>();
        _col = GetComponent<CapsuleCollider2D>();
    }

    private void FixedUpdate()
    {
        if (_col.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            airJumpCount = 0;
        }
    }

    public void Jump()
    {
        if (maxJumps <= 0)

            return;

        else if (_col.IsTouchingLayers(LayerMask.GetMask("Ground")) && airJumpCount == 0)
        {
            _rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }

        else if (airJumpCount < maxJumps - 1)
        {
            // обнуление по y-координате, чтобы второй прыжок был той же силы, что и первый
            var reset = _rb.velocity;
            reset.y = 0.0f;
            _rb.velocity = reset;

            _rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);

            airJumpCount++;
        }
    }
}


