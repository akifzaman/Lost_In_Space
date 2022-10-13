using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StarBehaviour : MonoBehaviour
{
    public GameObject player;
    public float speed = 10.0f;
    public Rigidbody2D starRb;

    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        starRb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive)
        {
            Vector2 direction = (player.transform.position - transform.position).normalized * speed;
            starRb.velocity = new Vector2(direction.x, direction.y);
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}