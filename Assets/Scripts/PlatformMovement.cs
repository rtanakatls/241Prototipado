using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    private Rigidbody2D rb2d;
    [SerializeField] private float speed;
    [SerializeField] private Vector2 direction;
    private float timer;
    [SerializeField] private float maxTimer;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        timer += Time.deltaTime;
        if(timer > maxTimer)
        {
            direction *= -1;
            timer = 0;
        }

        rb2d.velocity = direction * speed;
    }
}
