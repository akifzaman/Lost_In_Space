using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy_FollowPlayer : Enemy, IPooledObject
{
    [SerializeField] private float rotateAngle = 1.0f;
    [SerializeField] private bool lookDirectionAllow;
    
    private GameObject player;

    public void Update()
    {
        if (!GameManager.instance.isGameActive) return;
        transform.Rotate(0.0f, 0.0f * Time.deltaTime, rotateAngle, 0.0f);
        if (lookDirectionAllow && GameManager.instance.isGameActive)
        {
            if (transform.position.y > GameManager.instance.playerController.gameObject.transform.position.y)
            {
                Vector2 lookDirection = (GameManager.instance.playerController.gameObject.transform.position - transform.position).normalized;
                transform.Translate(lookDirection * Time.deltaTime * enemyProperties.Speed, Space.World);
            }
            else
            {
                lookDirectionAllow = false;
            }
        }
        else
        {
            transform.Translate(Vector2.down * Time.deltaTime * enemyProperties.Speed, Space.World);
        }
    }
    private void SetEnemyProperties(GameObject EnemyPrefab)
    {
        enemyProperties.Tag = "Enemy";
        enemyProperties.EnemySpawnDelay = 0.1f;
        enemyProperties.Speed = 3;
        enemyProperties.NumberSpawn = 150;
        enemyProperties.Boundary = 5.0f;
    }

    private void SetBulletProperties(GameObject bulletPrefab)
    {
        bulletProperties.Tag = "EnemyBullet_1";
        bulletProperties.BulletDelay = 0.5f;
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
