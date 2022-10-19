using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    public float speed = 3.0f;
    public float boundary = -5.5f;

    private PlayerHealthBar _playerHealthBar;

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
        if (gameObject.CompareTag("MiniBossBullet") && other.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            _playerHealthBar.DamageTaken(0.5f);
        }
        else if (gameObject.CompareTag("EnemyBullet") && other.gameObject.CompareTag("Player"))
        {
            _playerHealthBar.DamageTaken(1);
            Destroy(gameObject);
        }
    }
}
