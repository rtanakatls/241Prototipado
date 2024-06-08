using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private int life;
    [SerializeField] private int maxLife;
    private Animator animator;
    private UIController uiController;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        uiController = GameObject.Find("Canvas").GetComponent<UIController>();
        UpdateLife();
    }

    void UpdateLife()
    {
        uiController.ChangeLifeBar(life, maxLife);  
    }

    void ChangeLife(int value)
    {
        life += value;
        if (value < 0)
        {
            animator.SetTrigger("IsHit");
        }
        if(life > maxLife)
        {
            life = maxLife;
        }
        UpdateLife();
        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Hazard"))
        {
            ChangeLife(-1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Life"))
        {
            ChangeLife(1);
        }
    }

}
