using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public int lives;

    public float invincibilityTime;
    private bool invincible = false;

    public Vector2 movement;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        
    }


    public void PlayerMovement()
    {
      movement = Vector2.zero;
        if ((Input.GetKey(KeyCode.W)))
        {
            movement += Vector2.up;
        }
        if ((Input.GetKey(KeyCode.A)))
        {
            movement += Vector2.left;
            
        }
        if ((Input.GetKey(KeyCode.S)))
        {
            movement += Vector2.down;
        }
        if((Input.GetKey(KeyCode.D)))
        {
            movement += Vector2.right;
            Debug.Log(movement);
        }

        movement = movement.normalized;
       
        transform.Translate(movement * Time.deltaTime * speed);
    }
    public void TakeHit()
    {
        if (!invincible)
        {
            lives--;
            if (lives <= 0)
            {
                //ToDo: GameOver einleiten
            }
            else
            {
                invincible = true;
                StartCoroutine(InvincibilityCoro());
            }
        }
    }

    public IEnumerator InvincibilityCoro()
    {
        yield return new WaitForSecondsRealtime(invincibilityTime);
        invincible = false;
    }
}
