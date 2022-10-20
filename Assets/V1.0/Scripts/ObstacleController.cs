using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public float speed = 3.0f;
    public int obstacleEnergy;
    public GameObject enemyExplosion;
    public AudioClip obstacleSound;
    public AudioClip obstacleHitSound;

    [SerializeField] private float boundary = 6.0f;
    private PlayerHealthBar _playerHealthBar;

    void Start()
    {
        _playerHealthBar = GameObject.Find("Player").GetComponent<PlayerHealthBar>();
    }

    void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime * speed);
        if (transform.position.y < -boundary)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _playerHealthBar.UpdateSlider(2);
            GameObject explosion = Instantiate(enemyExplosion, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(obstacleSound, Camera.main.transform.position, 1.0f);
            Destroy(explosion, 0.5f);
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("bullet_lvl1") || other.gameObject.CompareTag("bullet_lvl2"))
        {
            Destroy(other.gameObject);
            AudioSource.PlayClipAtPoint(obstacleHitSound, Camera.main.transform.position, 1.0f);
            obstacleEnergy--;
            if (obstacleEnergy == 0)
            {
                GameObject explosion = Instantiate(enemyExplosion, transform.position, Quaternion.identity);
                AudioSource.PlayClipAtPoint(obstacleSound, Camera.main.transform.position, 1.0f);
                Destroy(explosion, 0.5f);
                Destroy(gameObject);
            }
        }
    }
}
