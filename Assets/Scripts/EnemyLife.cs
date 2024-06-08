using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    [SerializeField] private float life;

    void ChangeLife(int value)
    {
        life += value;
        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            Destroy(collision.gameObject);
            ChangeLife(-collision.gameObject.GetComponent<Bullet>().GetDamage());
        }
    }
}
