using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;

    private Vector2 moveDirection;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InputsValues();
    }

    void FixedUpdate()
    {
        Move();
    }

    void InputsValues()
    {
        float valueX = Input.GetAxisRaw("Horizontal");
        float valueY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(valueX, valueY);
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * speed, moveDirection.y * speed);
    }
}
