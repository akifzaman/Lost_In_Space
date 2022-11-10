using UnityEngine;

public class Enemy : MonoBehaviour,IPooledObject
{
    public float DamageAmount;

    public GameObject EnemyBullet;
    public GameObject ExplosionAnimation;

    public AudioClip enemyHitSound;
    public AudioClip ExplosionSound;

    protected AudioSource enemyAudioSource;
    [SerializeField] protected BulletProperties bulletProperties = new BulletProperties();
    public EnemyProperties enemyProperties;
    [SerializeField] protected Shooting shooting;
    [SerializeField] private float xBoundary = 3.20f;

    public float Speed { get; set; }
    public float Boundary { get; set; }

    private void Update()
    {
        if (!GameManager.instance.isGameActive) return;
        
        if (transform.position.x < -xBoundary || transform.position.x > xBoundary || transform.position.y < Boundary)
        {
            gameObject.SetActive(false);
        }
        transform.Translate(Vector2.down * Time.deltaTime * Speed, Space.World);
    }

    public virtual void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player_Bullet"))
        {
            enemyProperties.Health--;
            AudioSource.PlayClipAtPoint(enemyHitSound, Camera.main.transform.position, 0.1f);
            if (enemyProperties.Health <= 0)
            {
                GameManager.instance.UpdateScore(1);
                OnDestroyObject();
            }
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerController>().UpdateSlider(DamageAmount);
            OnDestroyObject();
        }
    }

    private void OnDestroyObject()
    {
        gameObject.SetActive(false);
        GameObject explosion = Instantiate(ExplosionAnimation, transform.position, Quaternion.identity);
        AudioSource.PlayClipAtPoint(ExplosionSound, Camera.main.transform.position, 1.0f);
        Destroy(explosion, 0.5f);
    }

    public virtual void OnObjectSpawn()
    {
        enemyAudioSource = GetComponent<AudioSource>();
        shooting = GetComponent<Shooting>();
    }

    
}
