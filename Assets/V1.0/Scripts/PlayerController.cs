using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    public float health = 100.0f;
    public bool isClashed = false;

    public GameObject glowShield;
    public GameObject parryShield;
    public GameObject enemyExplosion;

    public AudioClip powerUpSound;
    public AudioClip bulletSound;
    public AudioClip playerHitSound;

    public SpriteRenderer spriteRenderer;

    public SpeedPowerUp speedPowerUp;

    private float horizontalInput;
    private float verticalInput;
    private float xBoundary = 2.40f;
    private float yBoundaryUp = 4.78f;
    private float yBoundaryDown = -4.60f;
    private PlayerHealthBar _playerHealthBar;
    private AudioSource playerAudio;

    // Start is called before the first frame update
    void Start()
    {
        _playerHealthBar = GetComponent<PlayerHealthBar>();
        playerAudio = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if(!GameManager.instance.isGameActive) return;
        StayInBound();
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


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!(other.gameObject.CompareTag("HealthPowerUp") || other.gameObject.CompareTag("SpeedPowerUp") || other.gameObject.CompareTag("BulletPowerUp") ||
             other.gameObject.CompareTag("ShieldPowerUp")))
        {
            _playerHealthBar.DamageTaken(1);
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
