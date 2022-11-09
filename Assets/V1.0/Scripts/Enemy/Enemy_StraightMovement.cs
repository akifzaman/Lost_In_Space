using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_StraightMovement : Enemy, IPooledObject
{
    
    public GameObject EnemyPrefab;

    private void SetEnemyProperties(GameObject EnemyPrefab)
    {
        enemyProperties.Tag = "Enemy";
        enemyProperties.EnemySpawnDelay = 0.1f;
        enemyProperties.Speed = 5;
        enemyProperties.NumberSpawn = 150;
        enemyProperties.Boundary = 5.0f;
    }

    private void SetBulletProperties(GameObject bulletPrefab)
    {
        bulletProperties.Tag = "EnemyBullet_3";
        bulletProperties.BulletDelay = 0.9f;
        bulletProperties.Speed = -5f;
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
