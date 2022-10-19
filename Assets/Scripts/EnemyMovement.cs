using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMovement : MonoBehaviour
{

    public Transform target;
    public float speed = 3f;

    private void FixedUpdate()
    {
        transform.Translate((target.position - transform.position).normalized * speed * Time.deltaTime);
    }
}
