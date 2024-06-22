using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb2d;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    private bool canJump;

    [SerializeField] private Transform groundPoint;
    [SerializeField] private float groundRadius;
    [SerializeField] private LayerMask groundLayerMask;

    [SerializeField] private GameObject bulletPrefab;

    private AudioSource audioSource;
    [SerializeField] private AudioClip[] bulletClips;
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainScene");
        }
        Move();
        GroundCheck();
        Jump();
        Shoot();
    }

    void GroundCheck()
    {
        if (Physics2D.OverlapCircle(groundPoint.position, groundRadius, groundLayerMask))
        {
            canJump = true;
        }
        else
        {
            canJump = false;
        }
    }

    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            GameObject obj=Instantiate(bulletPrefab);
            obj.transform.position = transform.position;
            audioSource.PlayOneShot(bulletClips[Random.Range(0,bulletClips.Length)]);
            obj.GetComponent<Bullet>().SetDirection(new Vector2(transform.localScale.x, 0));
        }
    }

    void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");


        rb2d.velocity = new Vector2(horizontal * speed, rb2d.velocity.y);

        if (transform.parent != null)
        {
            if(transform.parent.GetComponent<Rigidbody2D>() != null && canJump)
            {
                Vector2 velocity = transform.parent.GetComponent<Rigidbody2D>().velocity;
                if (velocity.y > 0)
                {
                    velocity.y = 0;
                }

                rb2d.velocity += velocity;
            }
        }


        if (horizontal > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (horizontal < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (horizontal > 0 || horizontal < 0)
        {
            animator.SetBool("IsMoving", true);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }
    }

    void Jump()
    {
        animator.SetFloat("VerticalSpeed", rb2d.velocity.y);
        animator.SetBool("Grounded", canJump);
        if (canJump && Input.GetKeyDown(KeyCode.Space))
        {
            Vector2 velocity= rb2d.velocity;
            velocity.y = 0;
            rb2d.velocity = velocity;
            rb2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            canJump = false;
        }
    }

    private void OnDrawGizmos()
    {
        if (groundPoint != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundPoint.position, groundRadius);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            transform.SetParent(collision.transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            transform.SetParent(null);
        }
    }

}
