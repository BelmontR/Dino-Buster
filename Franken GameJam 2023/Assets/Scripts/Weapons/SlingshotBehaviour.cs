using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingshotBehaviour : ProjectileWeaponBehaviour
{
    SlingshotController sshot;
    Enemy enemy;

    public float speed = 30f;

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
        //if(sshot != null)
        //{
            transform.Translate(direction * speed * Time.deltaTime); //Set the movement of the slingshot
        Debug.Log(direction);
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Überprüfe, ob das kollidierte Objekt einen Health- oder Damage-Controller hat
        enemy = collision.gameObject.GetComponent<Enemy>();

        if (enemy != null)
        {
            // Füge Schaden hinzu
            enemy.TakeHit(10);

            //Wird bereits im Enemy überprüft
            /*
            // Überprüfe, ob die HP 0 ist und zerstöre das GameObject
            if (enemy.hp <= 0)
            {
               Destroy(collision.gameObject);
            }
            */

            // Zerstöre auch das Projektil
            Destroy(gameObject);
        }
    }

}
