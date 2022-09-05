using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject EnemyBullet;
    public Transform EnemyBulletSpawnPosition;

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
        yield return new WaitForSeconds(1);
        Fire();
        StartCoroutine(EnemyShoot());
    }
}