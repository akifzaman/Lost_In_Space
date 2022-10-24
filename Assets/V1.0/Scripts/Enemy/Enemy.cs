using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
public enum EnemyType
{
    FollowPlayer,
    RandomMovement,
    StraightMovement
}
public class Enemy : MonoBehaviour
{
    public EnemyType enemyType;
    public float speed;
    public float health;
    public GameObject EnemyBullet;

    public AudioClip enemyHitSound;

    public UnityEvent OnDestroyObject;
    protected AudioSource enemyAudioSource;
    [SerializeField]
    protected BulletProperties bulletProperties;
    protected Shooting shooting;
    [SerializeField] protected float xBoundary = 3.20f;
    [SerializeField] protected float yBoundary = -5.5f;
    public void SpawnEnemy()
    {
        
        enemyAudioSource = GetComponent<AudioSource>();
        SetBulletProperties(EnemyBullet);
        //shooting.Initialize(bulletProperties);
    }
    protected void SetBulletProperties(GameObject bulletPrefab)
    {
        bulletProperties.Tag = "EnemyBullet";
        bulletProperties.BulletDelay = 0.1f;
        bulletProperties.BulletPrefab = bulletPrefab;
    }

    public void Update()
    {
        if (!GameManager.instance.isGameActive) return;
        if (transform.position.x < -xBoundary || transform.position.x > xBoundary || transform.position.y < yBoundary)
        {
            gameObject.SetActive(false);
        }
    }
    protected void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player_Bullet"))
        {
            health--;
            AudioSource.PlayClipAtPoint(enemyHitSound, Camera.main.transform.position, 0.1f);
            if (health <= 0)
            {
                OnDestroyObject.Invoke();
            }
        }
    }
}
