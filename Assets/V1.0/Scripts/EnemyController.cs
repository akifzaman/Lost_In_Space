using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public SpeedPowerUp speedPowerUp;
    public int enemyHealth;
    public float speed = 3.0f;

    [SerializeField] private float boundary = 5.5f;
    [SerializeField] private float rotateAngle = 1.0f;
    [SerializeField] private bool lookDirectionAllow;

    private GameObject player;
    private Rigidbody2D enemyRb;

    private PlayerController playerController;

    private PlayerHealthBar _playerHealthBar;
    private PlayerHealthBar _enemyHealthBar;
    
    private AudioSource enemyAudioSource;

    public MiniBossActivate MiniBoss;
    public ShakeManager shakeManager;
    public SuperSplashActivate superSplashActivate;
    public bool isDestroyed = false;
    public GameObject laserObject;
    public bool laserActivate = false;
    public GameObject enemyExplosion;
    public GameObject laserReload;
    public Transform laserReloadPoint;

    public AudioClip explosionSound;
    public AudioClip enemyLaserSound;
    public AudioClip enemyLaserLoadSound;
    public AudioClip enemyHitSound;

    void Start()
    {
        _playerHealthBar = GameObject.Find("Player").GetComponent<PlayerHealthBar>();
        _enemyHealthBar = GameObject.Find("MiniBoss").GetComponent<PlayerHealthBar>();
        player = GameObject.Find("Player");
        MiniBoss = GameObject.Find("MiniBoss").GetComponent<MiniBossActivate>();
        shakeManager = GameObject.Find("Shake Manager").GetComponent<ShakeManager>();
        superSplashActivate = GameObject.Find("Player").GetComponent<SuperSplashActivate>();

        enemyAudioSource = GetComponent<AudioSource>();

        StartCoroutine(Laser());
    }

    void Update()
    {
        transform.Rotate(0.0f, 0.0f * Time.deltaTime, rotateAngle, 0.0f);

        if (lookDirectionAllow && GameManager.instance.isGameActive)
        {
            if (transform.position.y > player.transform.position.y)
            {
                Vector2 lookDirection = (player.transform.position - transform.position).normalized;
                transform.Translate(lookDirection * Time.deltaTime * speed, Space.World);

            }
            else
            {
                lookDirectionAllow = false;
            }
        }
        else if (GameManager.instance.isGameActive)
        {
            transform.Translate(Vector2.down * Time.deltaTime * speed, Space.World);
        }

        if (transform.position.y < boundary)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator Laser()
    {
        yield return new WaitForSeconds(3.0f);
        if (GameManager.instance.miniBossActive)
        {
            GameObject bossLaserReload = Instantiate(laserReload,  transform);
            AudioSource.PlayClipAtPoint(enemyLaserLoadSound, Camera.main.transform.position, 1.0f);
            Destroy(bossLaserReload, 1.0f);
            yield return new WaitForSeconds(1.0f);
            AudioSource.PlayClipAtPoint(enemyLaserSound, Camera.main.transform.position, 1.0f);
        }

        if (laserActivate)
        {
            laserObject.SetActive(true);
        }

        yield return new WaitForSeconds(1.0f);
        if (laserActivate)
        {
            laserObject.SetActive(false);
        }

        StartCoroutine(Laser());
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (gameObject.CompareTag("Enemy") && other.gameObject.CompareTag("Player"))
        {
            _playerHealthBar.DamageTaken(2);
            GameObject explosion = Instantiate(enemyExplosion, transform.position, Quaternion.identity);
            enemyAudioSource.PlayOneShot(explosionSound, 1.0f);
            Destroy(explosion, 0.5f);
            GameManager.instance.score++;
            Destroy(gameObject);
        }
        else if (gameObject.CompareTag("Enemy") && other.gameObject.CompareTag("bullet_lvl1") || other.gameObject.CompareTag("bullet_lvl2"))
        {
            enemyHealth--;
            AudioSource.PlayClipAtPoint(enemyHitSound, Camera.main.transform.position, 0.1f);
            if (enemyHealth <= 0)
            {
                GameObject explosion = Instantiate(enemyExplosion, transform.position, Quaternion.identity);
                AudioSource.PlayClipAtPoint(explosionSound, Camera.main.transform.position, 1.0f);
                Destroy(explosion, 0.5f);
                GameManager.instance.score++;
                Destroy(gameObject);
            }
        }
        else if (gameObject.CompareTag("MiniBoss") && other.gameObject.CompareTag("Player"))
        {
            _playerHealthBar.DamageTaken(20);
            Destroy(other.gameObject);
        }
        
        else if (gameObject.CompareTag("MiniBoss") && other.gameObject.CompareTag("bullet_lvl1"))
        {
            enemyHealth--;
            AudioSource.PlayClipAtPoint(enemyHitSound, Camera.main.transform.position, 0.1f);
            _enemyHealthBar.DamageTaken(1);
            if (enemyHealth <= 0)
            {
                GameObject explosion = Instantiate(enemyExplosion, transform.position, Quaternion.identity);
                AudioSource.PlayClipAtPoint(explosionSound,Camera.main.transform.position, 1.0f);
                GameManager.instance.miniBossActive = false;
                GameManager.instance.miniBossDestroyed = true;
                shakeManager.speed = 2.34f;
                shakeManager.amount = 0.06f;
                shakeManager.duration = 10.0f;
                Destroy(explosion, 0.5f);
                GameManager.instance.score +=100;
                Destroy(gameObject);
            }
        }

    }

}
