using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<IItem>() is IItem damageable)
        {
            damageable.OnTake(gameObject.GetComponent<Player>());
            Destroy(other.gameObject);
        }
    }
}
