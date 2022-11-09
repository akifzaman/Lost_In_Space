using UnityEngine;

public class SuperSplashBehaviour : MonoBehaviour
{
    public float speed;
    private float yBoundary = 5.5f;

    private AudioSource laserAudioSource;

    private HealthBar _enemyHealthBar;

    void Start()
    {
        laserAudioSource = GetComponent<AudioSource>();
       laserAudioSource.Play();
    }
    void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime * speed);
        if (transform.position.y > yBoundary)
        {
            DestroyImmediate(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Obstacles") || other.gameObject.CompareTag("EnemyBullet"))
        {
            other.gameObject.SetActive(false);
        }
        else if (other.gameObject.CompareTag("MiniBoss"))
        {
            _enemyHealthBar = other.gameObject.GetComponent<HealthBar>();
            _enemyHealthBar.UpdateSlider(10);
        }
    }
}
