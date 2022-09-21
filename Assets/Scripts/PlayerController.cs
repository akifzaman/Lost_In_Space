using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    private float xBoundary = 2.40f;
    private float yBoundaryUp = 4.78f;
    private float yBoundaryDown = -4.60f;
    public float speed = 10.0f;

    public float health = 100.0f;
    public GameObject glowShield;
    private PlayerHealthBar _playerHealthBar;

    private GameManager gameManager;
    public SpeedPowerUp speedPowerUp;

    public GameObject parryShield;
    public GameObject enemyExplosion;

    private AudioSource playerAudio;
    public AudioClip powerUpSound;
    public AudioClip bulletSound;
    public AudioClip playerHitSound;

    private Material matWhite;
    private Material matDefault;
    public SpriteRenderer spriteRenderer;

    public bool isClashed = false;

    // Start is called before the first frame update
    void Start()
    {
        _playerHealthBar = GameObject.Find("Player").GetComponent<PlayerHealthBar>();
        playerAudio = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        //matWhite = Resources.Load("WhiteFlash", typeof(Material)) as Material;
        //matDefault = spriteRenderer.material;
    }
    
    // Update is called once per frame
    void Update()
    {
        StayInBound();

        if (isClashed)
        {
            ColorChange();
            isClashed = false;
        }
        if (health == 0.0f)
        {
            Destroy(gameObject);
        }

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector2.left * Time.deltaTime * horizontalInput * speed);
        transform.Translate(Vector2.down * Time.deltaTime * verticalInput * speed);
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

    public void ActivateParryShield()
    {
        parryShield.SetActive(true);
    }
    public void DeactivateParryShield()
    {
        parryShield.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!(other.gameObject.CompareTag("HealthPowerUp") || other.gameObject.CompareTag("SpeedPowerUp") || other.gameObject.CompareTag("BulletPowerUp") ||
             other.gameObject.CompareTag("ShieldPowerUp")))
        {
            _playerHealthBar.DamageTaken(1);
            ///flash the player
            //spriteRenderer.material = matWhite;
            AudioSource.PlayClipAtPoint(playerHitSound, Camera.main.transform.position, 1.0f);
            isClashed = true;
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
