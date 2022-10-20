using UnityEngine;

public class SuperSplashBehaviour : MonoBehaviour
{
    public float speed = 15.0f;
    private float yBoundary = 5.5f;
    public Transform startPosition;

    private AudioSource laserAudioSource;
    public AudioClip laserExplosionSound;

    private PlayerHealthBar _enemyHealthBar;

    void Start()
    {
        laserAudioSource = GetComponent<AudioSource>();
        _enemyHealthBar = GameObject.Find("MiniBoss").GetComponent<PlayerHealthBar>();
    }
    void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime * speed);
        if (transform.position.y > yBoundary)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        GameObject bul1 = BulletPool.bulletPoolInstance.GetBullet1();
        GameObject bul2 = BulletPool.bulletPoolInstance.GetBullet2();

        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Obstacles") || other.gameObject.CompareTag("EnemyBullet"))
        {
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("MiniBoss"))
        {
            _enemyHealthBar.UpdateSlider(10);
        }
    }
}
