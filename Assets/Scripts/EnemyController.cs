using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 3.0f;
    [SerializeField] private float boundary = 5.5f;
    [SerializeField] private float rotateAngle = 1.0f;
    [SerializeField] private bool lookDirectionAllow;

    private GameObject player;

    private Rigidbody2D enemyRb;

    private PlayerController playerController;
    private PlayerHealthBar _playerHealthBar;

    public int enemyHealth;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        _playerHealthBar = GameObject.Find("Player").GetComponent<PlayerHealthBar>();
        player = GameObject.Find("Player");
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0.0f, 0.0f * Time.deltaTime, rotateAngle, 0.0f);

        if (lookDirectionAllow && gameManager.isGameActive)
        {
            if (transform.position.y > player.transform.position.y)
            {
                Vector2 lookDirection = (player.transform.position - transform.position).normalized;
                transform.Translate(lookDirection * Time.deltaTime * speed, Space.World);
            }
        }
        else if(gameManager.isGameActive)
        {
            transform.Translate(Vector2.down * Time.deltaTime * speed, Space.World);
        }

        transform.Translate(Vector2.down * Time.deltaTime * speed, Space.World);

        if (transform.position.y < boundary)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _playerHealthBar.DamageTaken(2);
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("bullet_lvl1") || other.gameObject.CompareTag("bullet_lvl2"))
        {
            enemyHealth--;
            if (enemyHealth == 0)
            {
                Destroy(gameObject);
            }
        }
        
    }

}
