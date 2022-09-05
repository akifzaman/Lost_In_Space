using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 10.0f;
 
    void Update()
    {
        if (gameObject.CompareTag("bullet_lvl1"))
        {
            transform.Translate(Vector2.down * Time.deltaTime * speed);
        }
        else if (gameObject.CompareTag("Enemy"))
        {
            transform.Translate(Vector2.up * Time.deltaTime * speed);
        }
        else if (gameObject.CompareTag("EnemyBullet"))
        {
            transform.Translate(Vector2.down * Time.deltaTime * speed);
        }
    }
}
