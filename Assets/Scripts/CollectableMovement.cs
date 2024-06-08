using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableMovement : MonoBehaviour
{
    private Rigidbody2D rb2d;
    [SerializeField] private float speed;
    [SerializeField] private Vector2 direction;
    [SerializeField] private float changeDirectionTimer;
    [SerializeField] private float changeDirectionDelay;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Timer();
        Move();
    }

    void Timer()
    {
        changeDirectionTimer += Time.deltaTime;
        if (changeDirectionTimer >= changeDirectionDelay)
        {
            direction *= -1;
            changeDirectionTimer = 0;
        }
    }

    void Move()
    {
        rb2d.velocity=direction*speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ChangeDirection"))
        {
            direction *= -1;
        }
    }
}
