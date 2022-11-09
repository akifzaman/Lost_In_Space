using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class PlayerController : MonoBehaviour
{
    public Player player;

    public GameObject superSplash;
    public GameObject glowShield;
    public GameObject ExplosionAnimation;

    public GameObject SingleBulletPrefab;
    public GameObject DoubleBulletPrefab;

    public AudioClip powerUpSound;
    public AudioClip bulletSound;
    public AudioClip playerHitSound;
    public AudioClip playerExplosionSound;

    public SpriteRenderer spriteRenderer;

    public SpeedPowerUp speedPowerUp;

    private float xBoundary = 2.40f;
    private float yBoundaryUp = 4.78f;
    private float yBoundaryDown = -4.60f;
    
    public HealthBar PlayerHealthBar;
    
    private Shooting shooting;
    private AudioSource playerAudio;

    public BulletProperties bulletProperties;

    void Start()
    {
        shooting = GetComponent<Shooting>();
        playerAudio = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        bulletProperties = new BulletProperties();
        PlayerHealthBar.gameObject.SetActive(false);
    }

    public void StartGame()
    {
        SetSlider();
        SetBulletProperties(SingleBulletPrefab, "SingleBullet");
    }

    private void SetSlider()
    {
        PlayerHealthBar.gameObject.SetActive(true);
        PlayerHealthBar.Initialize(player.health);
        PlayerHealthBar.OnMaximumValue.AddListener(OnDestroyPlayer);
    }

    public void UpdateSlider(float damageAmount) => PlayerHealthBar.UpdateSlider(damageAmount);
    public void ActivateShield() => glowShield.SetActive(true);
    
    private void SetBulletProperties(GameObject bulletPrefab, string tag)
    {
        bulletProperties.Tag = tag;
        bulletProperties.BulletDelay = 0.1f;
        bulletProperties.Speed = 10;
        bulletProperties.NumberSpawn = 150;
        bulletProperties.Boundary = 5.0f;
        bulletProperties.BulletPrefab = bulletPrefab;
        shooting.Initialize(bulletProperties);
        shooting.CanShoot = true;
        StartCoroutine(shooting.Fire(bulletProperties));
    }
    private void OnDestroyPlayer()
    {
        GameObject explosion = Instantiate(ExplosionAnimation, transform.position, Quaternion.identity);
        //AudioSource.PlayClipAtPoint(playerExplosionSound, Camera.main.transform.position, 1.0f);
        Destroy(explosion, 0.5f);
        Destroy(gameObject);
        GameManager.instance.isGameActive = false;
        GameManager.instance.GameOver();
    }
    void Update()
    {
        if(!GameManager.instance.isGameActive) return;
        StayInBound();
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector2.left * Time.deltaTime * horizontalInput * player.speed);
        transform.Translate(Vector2.down * Time.deltaTime * verticalInput * player.speed);

        SuperSplashActivated();
    }

    private void SuperSplashActivated()
    {
        if (Input.GetKeyDown(KeyCode.Space) && player.superSplashCounter > 0)
        {
            player.superSplashCounter--;
            GameManager.instance.UiManager.laserText.SetText("Laser: " + player.superSplashCounter);
            Instantiate(superSplash, superSplash.transform.position, superSplash.transform.rotation);
        }
    }

    private void StayInBound()
    {
        if (transform.position.x <= -xBoundary)
        {
            transform.position = new Vector2(-xBoundary, transform.position.y);
        }
        if (transform.position.x >= xBoundary)
        {
            transform.position = new Vector2(xBoundary, transform.position.y);
        }
        if (transform.position.y <= yBoundaryDown)
        {
            transform.position = new Vector2(transform.position.x, yBoundaryDown);
        }
        if (transform.position.y >= yBoundaryUp)
        {
            transform.position = new Vector2(transform.position.x, yBoundaryUp);
        }
    }

    //TODO- need to refactor
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("EnemyBullet"))
        {
            UpdateSlider(1.0f);
            other.gameObject.SetActive(false);
            AudioSource.PlayClipAtPoint(playerHitSound, Camera.main.transform.position, 1.0f);
        }
    }
}