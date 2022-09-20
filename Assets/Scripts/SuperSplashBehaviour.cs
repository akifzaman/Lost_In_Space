using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.ObjectChangeEventStream;

public class SuperSplashBehaviour : MonoBehaviour
{
    public float speed = 15.0f;
    private float yBoundary = 5.5f;
    public Transform startPosition;

    private AudioSource laserAudioSource;
    public AudioClip laserExplosionSound;

    void Start()
    {
        laserAudioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        //bul.GetComponent<Bullet>().SetMoveDirection(bulDir);
        transform.Translate(Vector2.up * Time.deltaTime * speed);
        if (transform.position.y > yBoundary)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        GameObject bul1 = BulletPool.bulletPoolInstance.GetBullet1();
        GameObject bul2 = BulletPool.bulletPoolInstance.GetBullet2();

        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Obstacles") || other.gameObject.CompareTag("EnemyBullet"))
        {
            //AudioSource.PlayClipAtPoint(laserExplosionSound, Camera.main.transform.position, 1.0f);
            Destroy(other.gameObject);
        }
    }
}
