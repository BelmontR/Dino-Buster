using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public int lives;

    public float invincibilityTime;
    public bool invincible = false;

    public GameObject axeController;
    public GameObject slingShotController;
    public GameObject spearController;
    public GameObject clubController;

    private Vector2 movement;

    private float speedSaveState;
    private float invincibilityTimeSaveState;

    // Start is called before the first frame update
    void Start()
    {
        speedSaveState = speed;
        invincibilityTimeSaveState = invincibilityTime;

        axeController.SetActive(false);
        slingShotController.SetActive(false);
       // spearController.SetActive(false);
        clubController.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
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
        if ((Input.GetKey(KeyCode.D)))
        {
            movement += Vector2.right;
        }

        if(movement == Vector2.zero)
        {
            GetComponent<Animator>().Play("Idle");
        }
        else
        {
            GetComponent<Animator>().Play("Walk");
        }

        transform.Translate(movement.normalized * Time.deltaTime * speed);
    }

    public void TakeHit()
    {
        if (!invincible)
        {
            lives--;
            UIManager.instance.RemoveHeart();
            if (lives <= 0)
            {
                //ToDo: GameOver einleiten
                UIManager.instance.GameOver();
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

    public Vector2 GetMovement()
    {
        return movement;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            TakeHit();
        }
    }

    public void ResetSpeed()
    {
        speed = speedSaveState;
    }

    public void ResetInvincTime()
    {
        invincibilityTime = invincibilityTimeSaveState;
    }
}
