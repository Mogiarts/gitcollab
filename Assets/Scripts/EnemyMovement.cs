using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMovement : MonoBehaviour
{

    Transform target;
    public float speed = 3f;
    public float rotationSpeed = 3f;

    private void FixedUpdate()
    {
        target = GameObject.FindWithTag("Player").transform;
        Vector3 targetHeading = target.position - transform.position;
        Vector3 targetDirection = targetHeading.normalized;

        //rotate to look at the player

        transform.rotation = Transform.LookAt(target.transform.position, new Vector3(0,0,0));

        //move towards the player
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}
