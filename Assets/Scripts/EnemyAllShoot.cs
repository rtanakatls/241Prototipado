using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemyAllShoot : MonoBehaviour
{
    [SerializeField] private Vector2[] directions;
    [SerializeField] private GameObject bulletPrefab;
    private float timer;
    [SerializeField] private float shootDelay;
    private void Update()
    {

        timer += Time.deltaTime;
        if (timer >= shootDelay)
        {
            for (int i = 0; i < directions.Length; i++)
            {
                GameObject obj = Instantiate(bulletPrefab);
                obj.transform.position = transform.position;
                obj.GetComponent<Bullet>().SetDirection(directions[i].normalized);

            }
            timer = 0;
        }
    }
}
