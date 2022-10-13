using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyBulletAngle : MonoBehaviour
{
    public float speed = 3.0f;
    public Rigidbody2D bulletRb;

    private GameManager gameManager;

    public GameObject player;
    private GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        bulletRb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
        enemy = GameObject.Find("Enemy");
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        bool check = (enemy.transform.position.y < player.transform.position.y);
        if (gameManager.isGameActive && !check)
        {
            Vector2 direction = (player.transform.position - transform.position).normalized * speed;
            bulletRb.velocity = new Vector2(direction.x, direction.y);
        }
        else if ( gameManager.isGameActive && check)
        {
            Vector2 direction = Vector2.down * speed;
            bulletRb.velocity = new Vector2(direction.x, direction.y);
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
