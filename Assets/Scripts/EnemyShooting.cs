using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject EnemyBullet;
    public Transform EnemyBulletSpawnPosition;
    public float enemyBulletDelay;
    private Vector2 offset = new Vector2(10.0f, 0);

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemyShoot());
    }

    void Fire()
    {
        Instantiate(EnemyBullet, EnemyBulletSpawnPosition.position, EnemyBullet.transform.rotation);
    }
    IEnumerator EnemyShoot()
    {
        yield return new WaitForSeconds(enemyBulletDelay);
        Fire();
        StartCoroutine(EnemyShoot());
    }
}