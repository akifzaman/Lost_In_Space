using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_RandomMovement : Enemy, IPooledObject
{
    private bool right = false;
    private float initialPosition = 0;
    private float horizontalSpeed = 1.0f;
    
    void Update()
    {
        if (GameManager.instance.isGameActive)
        {
            if (right)
            {
                transform.Translate(Vector2.right * Time.deltaTime * horizontalSpeed);
                if (transform.position.x > initialPosition + 0.5f)
                {
                    right = false;
                }
            }
            else if (!right)
            {
                transform.Translate(Vector2.left * Time.deltaTime * horizontalSpeed * 1.5f);
                if (transform.position.x < initialPosition - 0.5f)
                {
                    right = true;
                }
            }
            transform.Translate(Vector2.down * Time.deltaTime * enemyProperties.Speed, Space.World);
        }
    }
    private void SetEnemyProperties(GameObject EnemyPrefab)
    {
        enemyProperties.Tag = "Enemy";
        enemyProperties.EnemySpawnDelay = 0.1f;
        enemyProperties.Speed = 2;
        enemyProperties.NumberSpawn = 150;
        enemyProperties.Boundary = 5.0f;
    }

    private void SetBulletProperties(GameObject bulletPrefab)
    {
        bulletProperties.Tag = "EnemyBullet_2";
        bulletProperties.BulletDelay = 1f;
        bulletProperties.Speed = -7f;
        bulletProperties.NumberSpawn = 150;
        bulletProperties.Boundary = -5.5f;
        bulletProperties.BulletPrefab = bulletPrefab;
    }

    public override void OnObjectSpawn()
    {
        enemyAudioSource = GetComponent<AudioSource>();
        SetBulletProperties(EnemyBullet);

        shooting.CanShoot = !GameManager.instance.OnSpeedUp;
        StartCoroutine(shooting.Fire(bulletProperties));
    }
    private void OnEnable()
    {
        shooting = GetComponent<Shooting>();
        shooting.CanShoot = !GameManager.instance.OnSpeedUp;
    }
}
