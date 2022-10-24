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
    public AudioClip superSplashSound;
    public AudioClip playerExplosionSound;

    public SpriteRenderer spriteRenderer;

    public SpeedPowerUp speedPowerUp;

    private float horizontalInput;
    private float verticalInput;
    private float xBoundary = 2.40f;
    private float yBoundaryUp = 4.78f;
    private float yBoundaryDown = -4.60f;
    private PlayerHealthBar _playerHealthBar;
    private Shooting shooting;
    private AudioSource playerAudio;

    public BulletProperties bulletProperties;

    void Start()
    {
        shooting = GetComponent<Shooting>();
        playerAudio = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        bulletProperties = new BulletProperties();
    }

    public void StartGame(GameObject playerHealthBarSlider)
    {
        SetSlider(playerHealthBarSlider);
        SetBulletProperties(SingleBulletPrefab);
        shooting.Initialize(bulletProperties);
    }

    private void SetSlider(GameObject playerHealthBarSlider)
    {
        _playerHealthBar = playerHealthBarSlider.GetComponent<PlayerHealthBar>();
        _playerHealthBar.maximumDamageValue = 15f;
        _playerHealthBar.Initialize();
        _playerHealthBar.OnMaximumValue.AddListener(() =>
        {
            GameObject explosion = Instantiate(ExplosionAnimation, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(playerExplosionSound, Camera.main.transform.position, 1.0f);
            Destroy(explosion, 0.5f);
            Destroy(gameObject);
            GameManager.instance.GameOver();
        });
    }

    private void SetBulletProperties(GameObject bulletPrefab)
    {
        bulletProperties.Tag = "SingleBullet";
        bulletProperties.BulletDelay = 0.1f;
        bulletProperties.Speed = 10;
        bulletProperties.NumberSpawn = 150;
        bulletProperties.Boundary = 5.0f;
        bulletProperties.BulletPrefab = bulletPrefab;
    }

    void Update()
    {
        if(!GameManager.instance.isGameActive) return;
        StayInBound();
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector2.left * Time.deltaTime * horizontalInput * player.speed);
        transform.Translate(Vector2.down * Time.deltaTime * verticalInput * player.speed);

        SuperSplashActivated();
    }

    private void SuperSplashActivated()
    {
        if (Input.GetKeyDown(KeyCode.Space) && player.superSplashCounter > 0)
        {
            player.superSplashCounter--;

            GameManager.instance.laserCount--;
            playerAudio.PlayOneShot(superSplashSound, 0.7f);
            Instantiate(superSplash, superSplash.transform.position, superSplash.transform.rotation);
        }
    }

    void StayInBound()
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

    public void ActivateShield()
    {
        glowShield.SetActive(true);
    }


    //TODO- need to refactor
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!(other.gameObject.CompareTag("HealthPowerUp") || other.gameObject.CompareTag("SpeedPowerUp") || other.gameObject.CompareTag("BulletPowerUp") ||
             other.gameObject.CompareTag("ShieldPowerUp")))
        {
            _playerHealthBar.UpdateSlider(1);
            AudioSource.PlayClipAtPoint(playerHitSound, Camera.main.transform.position, 1.0f); //need to change
        }

        else if (other.gameObject.CompareTag("HealthPowerUp") || other.gameObject.CompareTag("SpeedPowerUp") || other.gameObject.CompareTag("BulletPowerUp") ||
                           other.gameObject.CompareTag("ShieldPowerUp"))
        {
            playerAudio.PlayOneShot(powerUpSound, 1.0f);
        }

    }

    void ColorChange()
    {
        for (int i = 0; i < 10; i++)
        {
            spriteRenderer.color = Color.red;
            Invoke("ResetColor", 0.2f);
        }
    }
    void ResetColor()
    {
        spriteRenderer.color = Color.yellow;
    }


}