using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public float speed = 3.0f;
    [SerializeField] private float boundary = 6.0f;

    private PlayerController playerController;
    private PlayerHealthBar _playerHealthBar;

    private GameManager gameManager;

    public SpeedPowerUp speedPowerUp;

    public int obstacleEnergy;

    public GameObject enemyExplosion;

    private AudioSource obstacleSoundSource;
    public AudioClip obstacleSound;

    // Start is called before the first frame update
    void Start()
    {
        _playerHealthBar = GameObject.Find("Player").GetComponent<PlayerHealthBar>();
    }

    // Update is called once per frame
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
            _playerHealthBar.DamageTaken(2);
            GameObject explosion = Instantiate(enemyExplosion, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(obstacleSound, Camera.main.transform.position, 1.0f);
            Destroy(explosion, 0.5f);
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("bullet_lvl1") || other.gameObject.CompareTag("bullet_lvl2"))
        {
            Destroy(other.gameObject);
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
