using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    private Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

    }
    public void Shoot(Vector3 direction)
    {
        //transform.Translate(direction.normalized * Time.deltaTime * 5);
        rb.velocity = direction.normalized * 5;
    }
}
