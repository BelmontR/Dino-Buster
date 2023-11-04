using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingshotController : WeaponController
{
    public bool aimWithCursor;

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
        GameObject spawnedSlingshot = Instantiate(prefab, spawnPosition, Quaternion.identity);

        if (!aimWithCursor)
        {
            // Passe die Projektilrichtung an
            spawnedSlingshot.GetComponent<SlingshotBehaviour>().DirectionChecker(playermovement.GetMovement().normalized);
        }
        else
        {
            // Holen Sie sich die Position des Mauszeigers im Worldspace.
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Berechnen Sie die Richtung zum Mauszeiger.
            Vector2 moveDirection = (mousePosition - transform.position).normalized;

            spawnedSlingshot.GetComponent<SlingshotBehaviour>().DirectionChecker(moveDirection);

        }
    }
}
