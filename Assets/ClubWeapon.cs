using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClubWeapon : MonoBehaviour
{
    float attackFrequency = 4f;
    float timer;
    
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0f)
        {
            Attack();
        }
    }

    private void Attack()
    {
        Debug.Log("Attack");
        timer = attackFrequency;
    }
}
