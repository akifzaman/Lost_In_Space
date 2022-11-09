using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBoss : Enemy, IPooledObject
{
    public GameObject laserObject;
    public GameObject laserReload;

    public AudioClip enemyLaserSound;
    public AudioClip enemyLaserLoadSound;

    private ShipMovement MiniBossMovement;
    public HealthBar BossHealthBar;

    private bool laserActivate = false;
    private float activationTime = 8.0f;
    private float activationPoint = 4.0f;

    public List<BulletProperties> bossBulletProperties;

    void Start()
    {
        MiniBossMovement = GetComponent<ShipMovement>();
        foreach (var bullet in bossBulletProperties)
        {
            Pool pool = new Pool();
            pool.prefab = bullet.BulletPrefab;
            pool.tag = bullet.Tag;
            pool.size = bullet.NumberSpawn;
            ObjectPooler.Instance.Initialize(pool);
        }
        StartCoroutine(Laser());
        BossHealthBar.gameObject.SetActive(false);
        SetSlider();
    }
    void Update()
    {
        if (GameManager.instance.timeCounter <= -activationTime)
        {
            if (gameObject.CompareTag("MiniBoss") && transform.position.y < activationPoint)
            {
                GameManager.instance.miniBossActive = true;
                BossHealthBar.gameObject.SetActive(true);
                laserActivate = true;
            }
            if (gameObject.CompareTag("MiniBoss") && transform.position.y > activationPoint)
            {
                transform.Translate(Vector2.down * Time.deltaTime * MiniBossMovement.moveSpeed / 2.0f);
            }
        }
    }
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
            //other.gameObject.GetComponent<PlayerController>().UpdateSlider(DamageAmount);
            GameManager.instance.GameOver();
        }
    }
    public void SetSlider()
    {
        //BossHealthBar.gameObject.SetActive(true);
        BossHealthBar.Initialize(enemyProperties.Health);
        BossHealthBar.OnMaximumValue.AddListener(OnDestroyBoss);
    }

    public void UpdateSlider(float damageAmount) => BossHealthBar.UpdateSlider(damageAmount);

    private void OnDestroyBoss()
    {
        GameObject explosion = Instantiate(ExplosionAnimation, transform.position, Quaternion.identity);
        //AudioSource.PlayClipAtPoint(playerExplosionSound, Camera.main.transform.position, 1.0f);
        Destroy(explosion, 0.5f);
        Destroy(gameObject);
        GameManager.instance.isGameActive = false;
        GameManager.instance.GameOver();
    }

    //TODO- need to refactor
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
