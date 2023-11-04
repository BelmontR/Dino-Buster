using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeController : WeaponController
{
       Enemy enemy;
    [SerializeField] GameObject leftAxeSwing;
    [SerializeField] GameObject rightAxeSwing;
    public float strength;
    public float kbStrength;
    public float kbLength;
 protected override void Start()
    {
        base.Start();
    }

    protected override void Attack()
    {
        base.Attack();

        // Finde die Position des Spielers
        Vector3 playerPosition = transform.position;

        // Konvertiere die Vector2 in eine Vector3 und setze den Z-Wert auf 0
        Vector3 playerMovement3D = new Vector3(playermovement.GetMovement().x, playermovement.GetMovement().y, 0f);

        // Berechne die Spawn-Position vor dem Spieler
        Vector3 spawnPosition = playerPosition + (playerMovement3D.normalized * 1f); // Anpassen des Abstands nach Bedarf

        // Erzeuge das Projektil an der berechneten Spawn-Position
        GameObject spawnedAxe = Instantiate(prefab, spawnPosition, Quaternion.identity);

        spawnedAxe.GetComponent<AxeController>().strength = damage;
        spawnedAxe.GetComponent<AxeController>().kbStrength = knockbackStrength;
        spawnedAxe.GetComponent<AxeController>().kbLength = knockbackLength;

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
