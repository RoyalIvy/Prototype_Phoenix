using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : Hero
{

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
            other.transform.parent = transform;
    }

    protected override void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
            other.transform.parent = null;
    }
}
