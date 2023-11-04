using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHitbox : MonoBehaviour
{
    public float strength;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var enemy = collision.GetComponent<Enemy>();
        if(enemy != null)
        {
            enemy.TakeHit(strength);
        }
    }
}
