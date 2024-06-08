using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb2d;
    [SerializeField] private float speed;
    [SerializeField] private Vector2 direction;
    [SerializeField] private int damage;

    public int GetDamage()
    {
        return damage;
    }

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    public void SetDirection(Vector2 direction)
    {
        this.direction = direction;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        rb2d.velocity = direction * speed;
    }
}
