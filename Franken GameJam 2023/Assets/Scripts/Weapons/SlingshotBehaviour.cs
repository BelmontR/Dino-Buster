using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingshotBehaviour : ProjectileWeaponBehaviour
{
    SlingshotController sshot;
    Enemy enemy;

    public float speed = 30f;
    public float strength;
    public float kbStrength;
    public float kbLength;

    protected override void Start()
    {
         //sshot = GetComponent<SlingshotController>();
         if(sshot == null)
         {
            //Debug.LogError("ShlingshotController not found on this gameobject");
         }
    }

    
    void Update()
    {
        //if(sshot != null)
        //{
        transform.Translate(direction.normalized * speed * Time.deltaTime); //Set the movement of the slingshot

        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Überprüfe, ob das kollidierte Objekt einen Health- oder Damage-Controller hat
        enemy = collision.gameObject.GetComponent<Enemy>();

        if (enemy != null)
        {
            // Füge Schaden hinzu
            enemy.TakeHit(strength);
            enemy.TakeKnockback(this.gameObject, kbStrength, kbLength);

            // Zerstöre auch das Projektil
            Destroy(gameObject);
        }
        else if(collision.gameObject.GetComponent<Wall>() != null)
        {
            // Zerstöre auch das Projektil
            Destroy(gameObject);
        }
    }

}
