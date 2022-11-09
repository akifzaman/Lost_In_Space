using UnityEngine;

public class ObstacleController : MonoBehaviour, IPooledObject
{
    public float DamageAmount;

    public GameObject ExplosionAnimation;
    public AudioClip ObstacleHitSound;
    public AudioClip ExplosionSound;

    [SerializeField] private float boundary = 6.0f;

    [SerializeField] private ObstacleProperties obstacleProperties;

    public float Speed { get; set; }
    public float Boundary { get; set; }
    void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime * obstacleProperties.Speed);
        if (transform.position.y < -boundary)
        {
            gameObject.SetActive(false);
        }
    }
    protected void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player_Bullet"))
        {
            obstacleProperties.Health--;
            AudioSource.PlayClipAtPoint(ObstacleHitSound, Camera.main.transform.position, 0.1f);
            if (obstacleProperties.Health <= 0)
            {
                GameManager.instance.UpdateScore(1);
                OnDestroyObject();
            }
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

    public void OnObjectSpawn()
    {
        
    }
}
