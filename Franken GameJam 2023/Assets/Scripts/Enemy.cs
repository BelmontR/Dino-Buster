using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    public float speed = 30;
    public float hp;
    public int strength;
    public SpriteRenderer sprite;

    private Stats stats;

    private Vector2 movement;

    [Range(0f,1f)]
    public float dropRate;
    public GameObject drop;

    public int scoreValue = 10;

    private Transform target;

    [SerializeField]
    private Rigidbody2D rb;

    private bool blockMovement = false;

    // Start is called before the first frame update
    void Start()
    {
        target = GameManager.instance.player.transform;
        stats = new Stats(speed, hp, strength, dropRate);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!blockMovement)
        {
            movement = (target.position - this.transform.position).normalized;
            transform.Translate(movement * Time.deltaTime * stats.GetSpeed());
            if(target.position.x < transform.position.x)
            {
                sprite.flipX = true;
            }
            else
            {
                sprite.flipX = false;
            }
        }
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
        GameManager.instance.AddToScore(scoreValue);
        GameManager.instance.IncrementKilledEnemies();

        if (drop != null)
        {
            Instantiate(drop, transform.position, Quaternion.identity);
        }

        Destroy(this.gameObject);     
    }

    #region Knockback

    public void TakeKnockback(GameObject sender, float kbStrength, float kbLength)
    {
        StopAllCoroutines();

        blockMovement = true;

        Vector2 dir = (transform.position - sender.transform.position).normalized;
        rb.AddForce(dir * kbStrength, ForceMode2D.Impulse);
        StartCoroutine(ResetKnockback(kbLength));


    }

    private IEnumerator ResetKnockback(float delay)
    {
        yield return new WaitForSeconds(delay);
        rb.velocity = Vector3.zero;
        blockMovement = false;
    }

    #endregion

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
