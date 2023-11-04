using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [Header("Weapon Stats")]
    public GameObject prefab;
    public float damage;
    public float frequency;
    public float cooldownDuration;
    float currentCooldown;
    public int pierce;

    public float knockbackStrength;
    public float knockbackLength;

    protected Player playermovement;

   protected virtual void Start()
    {
        playermovement = FindObjectOfType<Player>();
        currentCooldown = cooldownDuration; // start with the cooldown duration as current cooldown
    }

    protected virtual void Update()
    {
        currentCooldown -= Time.deltaTime;
        if(currentCooldown <= 0f) // once cooldown becomes 0, attack
        {
            Attack();
        }
    }

    protected virtual void Attack()
    {
        currentCooldown = cooldownDuration;
    }
}
