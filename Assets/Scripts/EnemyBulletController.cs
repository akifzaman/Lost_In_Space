using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    public float speed = 3.0f;
    public float boundary = -5.5f;

    private PlayerController playerController;
    private PlayerHealthBar _playerHealthBar;

    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        _playerHealthBar = GameObject.Find("Player").GetComponent<PlayerHealthBar>();
    }

    void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime * speed);
        
        if (transform.position.y < boundary)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _playerHealthBar.DamageTaken(1);
            Destroy(gameObject);
        }
    }
}
