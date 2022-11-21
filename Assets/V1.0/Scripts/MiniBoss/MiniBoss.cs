using System.Collections;
using UnityEngine;
public class MiniBoss : Enemy
{
    public GameObject laserObject;
    public GameObject laserReload;

    public AudioClip enemyLaserSound;
    public AudioClip enemyLaserLoadSound;

    private ShipMovement MiniBossMovement;
    public HealthBar BossHealthBar;

    private bool laserActivate = false;
    private float activationPoint = 4.0f;

    void Start()
    {
        MiniBossMovement = GetComponent<ShipMovement>();
        StartCoroutine(Laser());
        BossHealthBar.gameObject.SetActive(false);
        SetSlider();
    }
    private bool shoot = false;
    void Update()
    {
        MiniBossProjectileActivation();
        MiniBossMoveDown();
    }

    private void MiniBossProjectileActivation()
    {
        if (transform.position.y < activationPoint)
        {
            if (shoot) return;
            BossHealthBar.gameObject.SetActive(true);
            laserActivate = true;
            shoot = true;
        }
    } private void MiniBossMoveDown()
    {
        if (transform.position.y > activationPoint && GameManager.instance.miniBossActive)
        {
            transform.Translate(Vector2.down * Time.deltaTime * MiniBossMovement.moveSpeed / 2.0f);
        }
    }
    public void SetSlider()
    {
        BossHealthBar.Initialize(enemyProperties.Health);
        BossHealthBar.OnMaximumValue.AddListener(OnDestroyBoss);
    }
    public void UpdateSlider(float damageAmount) => BossHealthBar.UpdateSlider(damageAmount);

    public override void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player_Bullet"))
        {
            enemyProperties.Health--;
            UpdateSlider(1.0f);
            AudioSource.PlayClipAtPoint(enemyHitSound, Camera.main.transform.position, 0.1f);
            if (enemyProperties.Health <= 0)
            {
                GameManager.instance.UpdateScore(100);
                OnDestroyBoss();
            }
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.instance.GameOver();
        }
    }
    private void OnDestroyBoss()
    {
        GameObject explosion = Instantiate(ExplosionAnimation, transform.position, Quaternion.identity);
        Destroy(explosion, 0.5f);
        Destroy(gameObject);
        GameManager.instance.isGameActive = false;
        GameManager.instance.GameOver();
    }
    IEnumerator Laser()
    {
        yield return new WaitForSeconds(3.0f);
        if (GameManager.instance.miniBossActive)
        {
            GameObject bossLaserReload = Instantiate(laserReload, transform);
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
}
