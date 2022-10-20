using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMovement : MonoBehaviour
{

    GameObject target;
    public float speed = 3f;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player");     
    }

    private void FixedUpdate()
    {
        transform.Translate((target.transform.position - transform.position).normalized * speed * Time.deltaTime);
    }
}
