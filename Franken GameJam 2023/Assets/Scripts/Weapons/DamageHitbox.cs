using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class DamageHitbox : MonoBehaviour
{
    public float strength;
    public float kbStrength;
    public float kbLength;

    public dmgHbStats stats;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var enemy = collision.GetComponent<Enemy>();
        if(enemy != null)
        {
            enemy.TakeHit(stats.strength);
            enemy.TakeKnockback(this.gameObject, stats.kbStrength, stats.kbLength);
        }
    }

    public class dmgHbStats
    {
        public float strength;
        public float kbStrength;
        public float kbLength;

        public dmgHbStats(float strength, float kbStrength, float kbLength)
        {
            this.strength = strength;
            this.kbStrength = kbStrength;
            this.kbLength = kbLength;
        }

        public void IncreaseStrength(float multiplicator)
        {
            strength *= multiplicator;
        }

        public void IncreaseKbStrength(float multiplicator)
        {
            kbStrength *= multiplicator;
        }

        public void IncreaseKbLength(float multiplicator)
        {
            kbStrength *= multiplicator;
        }

        public void SetStrength(float str)
        {
            strength = str;
        }

        public void SetKbStrength(float kbstr)
        {
            kbStrength = kbstr;
        }

        public void SetKbLength(float kblgt)
        {
            kbLength = kblgt;
        }
    }
}
