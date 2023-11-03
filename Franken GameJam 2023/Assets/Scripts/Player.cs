using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    private Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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
        }

        transform.Translate(movement.normalized * Time.deltaTime * speed);
    }
}
