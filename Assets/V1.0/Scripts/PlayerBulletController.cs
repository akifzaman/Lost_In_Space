using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletController : MonoBehaviour
{
    public float speed = 10.0f;
    public float boundary = 5.3f;

    private EnemyController enemyController;
    // Start is called before the first frame update
    void Start()
    { 
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime * speed);
        if (transform.position.y > boundary)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("MiniBoss") || other.gameObject.CompareTag("MainBoss"))
        {
            //Destroy(other.gameObject);
            Destroy(gameObject);

        }
    }
}
