using System.Collections;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject EnemyBullet;
    public Transform EnemyBulletSpawnPosition;
    
    [SerializeField] private float enemyBulletDelay = 0.3f;

    void Start()
    {
        StartCoroutine(EnemyShoot());
    }

    void Fire()
    {
        if (GameManager.instance.isSpeedUp)
        {
            Instantiate(EnemyBullet, new Vector2(2.0f, -6.0f), EnemyBullet.transform.rotation);
        }
        Instantiate(EnemyBullet, EnemyBulletSpawnPosition.position, EnemyBullet.transform.rotation);
    }
    IEnumerator EnemyShoot()
    {
        yield return new WaitForSeconds(enemyBulletDelay);
        if (GameManager.instance.isGameActive && !GameManager.instance.isSpeedUp)
        {
            Fire();
        }
        StartCoroutine(EnemyShoot());
    }
}