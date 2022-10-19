using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Bullets bullets;

    public float speed;
    public Rigidbody2D rb;

    private Vector2 moveDirection;

    public GameObject firePoint;
    public GameObject bullet;


    void Update()
    {
        InputsValues();

        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(
            mousePosition.x - transform.position.x,
            mousePosition.y - transform.position.y
        );

        transform.up = direction;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject thisBullet = Instantiate(bullet, firePoint.transform.position, Quaternion.identity);
            thisBullet.GetComponent<Bullets>().Shoot(direction);
        }
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

    public void Move(){
        rb.velocity = new Vector2(moveDirection.x * speed, moveDirection.y * speed);
    }
}
