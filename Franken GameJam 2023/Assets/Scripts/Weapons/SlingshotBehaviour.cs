using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingshotBehaviour : ProjectileWeaponBehaviour
{
    SlingshotController sshot;
    Enemy enemy;
    protected override void Start()
    {
         sshot = GetComponent<SlingshotController>();
         if(sshot == null)
         {
            Debug.LogError("ShlingshotController not found on this gameobject");
         }
    }

    
    void Update()
    {
        if(sshot != null)
        {
            transform.position += direction * sshot.frequency * Time.deltaTime; //Set the movement of the slingshot
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
{
    // Überprüfe, ob das kollidierte Objekt einen Health- oder Damage-Controller hat
     Enemy enemy = collision.gameObject.GetComponent<Enemy>();

    if (enemy != null)
    {
        // Füge Schaden hinzu
        enemy.TakeHit(10);

        // Überprüfe, ob die HP 0 ist und zerstöre das GameObject
        if (enemy.hp <= 0)
        {
            Destroy(collision.gameObject);
        }

        // Zerstöre auch das Projektil
        Destroy(gameObject);
    }
}

}
