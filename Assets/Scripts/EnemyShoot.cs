using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private GameObject enemyBulletPrefab;
    [SerializeField] private float shootDelay;
    [SerializeField] private float rangeDistance;
    private Transform target;
    private float timer;

    private void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        if (target!=null)
        {
            if (Vector2.Distance(transform.position, target.position) <= rangeDistance)
            {
                timer += Time.deltaTime;
                if (timer >= shootDelay)
                {
                    Vector2 direcion = target.position - transform.position;
                    direcion.y = 0;
                    direcion = direcion.normalized;
                    GameObject obj = Instantiate(enemyBulletPrefab);
                    obj.transform.position = transform.position;
                    obj.GetComponent<Bullet>().SetDirection(direcion);
                    timer = 0;
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, rangeDistance);
    }

}
