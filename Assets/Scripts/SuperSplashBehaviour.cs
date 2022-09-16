using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperSplashBehaviour : MonoBehaviour
{
    public float speed = 15.0f;
    private float yBoundary = 5.5f;
    public Transform startPosition;
    void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime * speed);
        if (transform.position.y > yBoundary)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Obstacles") || other.gameObject.CompareTag("EnemyBullet") || other.gameObject.CompareTag("MiniBossBullet"))
        {
            Destroy(other.gameObject);
        }
    }
}
