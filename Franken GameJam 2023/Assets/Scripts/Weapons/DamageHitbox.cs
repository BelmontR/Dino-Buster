using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHitbox : MonoBehaviour
{
    public float strength;
    public float kbStrength;
    public float kbLength;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var enemy = collision.GetComponent<Enemy>();
        if(enemy != null)
        {
            enemy.TakeHit(strength);
            enemy.TakeKnockback(this.gameObject, kbStrength, kbLength);
        }
    }
}
