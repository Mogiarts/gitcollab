using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMovement : MonoBehaviour
{

    GameObject target;
    public float speed = 15f;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player");     
    }

    private void FixedUpdate()
    {
        transform.Translate((target.transform.position - transform.position) * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.gameState = GameManager.GameState.GameOver;
        }
    }
}
