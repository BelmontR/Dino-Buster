using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 30;
    public float hp = 10;
    public int strength;

    private Stats stats;

    private Vector2 movement;

    [Range(0f,1f)]
    public float dropRate;
    public GameObject drop;


    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        target = GameManager.instance.player.transform;
        stats = new Stats(speed, hp, strength, dropRate);
    }

    // Update is called once per frame
    void Update()
    {
        movement = (target.position - this.transform.position).normalized;
        transform.Translate(movement * Time.deltaTime * stats.GetSpeed());
    }

    public void TakeHit(float damage)
    {
        if(stats.TakeHit(damage))
        {
            Die();
        }
    }

    public void Die()
    {
        //ToDo: Drop Drops
        //ToDo: Todes-Animation
        GameManager.instance.currentEnemies--;
        Destroy(this.gameObject);     
    }

    private class Stats
    {
        private float speed;
        private float hp;
        private int strength;
        private float dropRate;

        public Stats(float speed, float hp, int strength, float dropRate)
        {
            this.speed = speed;
            this.hp = hp;
            this.strength = strength;
            this.dropRate = dropRate;
        }

        public bool TakeHit(float dmg)
        {
            hp -= dmg;
            return hp <= 0;
        }
        #region Setter und Getter

        public void SetSpeed(float speed)
        {
            this.speed = speed;
        }

        public float GetSpeed()
        {
            return speed;
        }

        public void SetStrength(int strength)
        {
            this.strength = strength;
        }

        public int GetStrength()
        {
            return strength;
        }

        public void SetDropRate(float dropRate)
        {
            this.dropRate = dropRate;
        }

        public float GetDropRate()
        {
            return dropRate;
        }

        #endregion


    }
}
