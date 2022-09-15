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

    public SpeedPowerUp speedPowerUp;

    public int enemyHealth;

    private GameManager gameManager;
    private StarSpawner starSpawner;
    public MiniBossActivate MiniBoss;
    public ShakeManager shakeManager;

    public SuperSplashActivate superSplashActivate;

    public bool isDestroyed = false;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        _playerHealthBar = GameObject.Find("Player").GetComponent<PlayerHealthBar>();
        player = GameObject.Find("Player");
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        starSpawner = GameObject.Find("StarSpawner").GetComponent<StarSpawner>();
        MiniBoss = GameObject.Find("MiniBoss").GetComponent<MiniBossActivate>();
        shakeManager = GameObject.Find("Shake Manager").GetComponent<ShakeManager>();
        superSplashActivate = GameObject.Find("Player").GetComponent<SuperSplashActivate>();
        anim = GetComponent<Animator>();
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
                gameManager.prevPosition = gameManager.currentPosition;
                gameManager.currentPosition = transform.position;

            }
        }
        else if (gameManager.isGameActive)
        {
            transform.Translate(Vector2.down * Time.deltaTime * speed, Space.World);
            gameManager.prevPosition = gameManager.currentPosition;
            gameManager.currentPosition = transform.position;
        }

        //transform.Translate(Vector2.down * Time.deltaTime * speed, Space.World);

        if (transform.position.y < boundary)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (gameObject.CompareTag("Enemy") && other.gameObject.CompareTag("Player"))
        {
            _playerHealthBar.DamageTaken(2);
            Destroy(gameObject);
        }
        else if (gameObject.CompareTag("MiniBoss") && other.gameObject.CompareTag("Player"))
        {
            //_playerHealthBar.DamageTaken(5);
            //Destroy(gameObject);
        }
        else if (gameObject.CompareTag("MainBoss") && other.gameObject.CompareTag("Player"))
        {
           // _playerHealthBar.DamageTaken(5);
            //Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("bullet_lvl1") || other.gameObject.CompareTag("bullet_lvl2"))
        {
            enemyHealth--;
            if (enemyHealth <= 0)
            {
                isDestroyed = true;
                //anim.Play("Explosion");
                //anim.SetTrigger("IsDestroy");
                //starSpawner.Spawn(gameManager.prevPosition);
                if (gameObject.CompareTag("MiniBoss"))
                {
                    gameManager.miniBossActive = false;
                    gameManager.miniBossDestroyed = true;
                    gameManager.mainBossActive = true;
                    shakeManager.speed = 2.34f;
                    shakeManager.amount = 0.06f;
                    shakeManager.duration = 10.0f;
                    //superSplashActivate.superSplashCounter = 5;
                }
                Destroy(gameObject);

            }
        }

    }

}
