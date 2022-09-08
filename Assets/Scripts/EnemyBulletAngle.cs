using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyBulletAngle : MonoBehaviour
{
    public GameObject player;
    public float speed = 3.0f;
    public Rigidbody2D bulletRb;
    // Start is called before the first frame update
    void Start()
    {
        bulletRb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
        Vector2 direction = (player.transform.position - transform.position).normalized * speed;
        bulletRb.velocity = new Vector2(direction.x, direction.y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
