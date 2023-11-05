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

    private void Start()
    {
        CallStart();
    }

    private void CallStart()
    {
        stats = new dmgHbStats(strength, kbStrength, kbLength);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var enemy = collision.GetComponent<Enemy>();
        if(enemy != null)
        {
            enemy.TakeHit(stats.strength);
            enemy.TakeKnockback(this.gameObject, stats.kbStrength, stats.kbLength);
        }
    }

    public void ResetStats()
    {
        if(stats == null)
        {
            Debug.Log("Die Stats sind Null");
            CallStart();
        }

        stats.SetStrength(strength);
        stats.SetKbStrength(kbStrength);
        stats.SetKbLength(kbLength);
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
            strength *= (1+ multiplicator);
        }

        public void IncreaseKbStrength(float multiplicator)
        {
            kbStrength *= (1 + multiplicator);
        }

        public void IncreaseKbLength(float multiplicator)
        {
            kbStrength *= (1+ multiplicator);
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
