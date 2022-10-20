using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    private Rigidbody2D rb;
    //private BoxCollider2D bc;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        //bc = gameObject.AddComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D enemy)
    {
        if (enemy.CompareTag("Enemy"))
        {
            Destroy(enemy.gameObject);
            Destroy(gameObject);
        }
    }
    public void Shoot(Vector3 direction)
    {
        //transform.Translate(direction.normalized * Time.deltaTime * 5);
        rb.velocity = direction.normalized * 5;
    }
}
