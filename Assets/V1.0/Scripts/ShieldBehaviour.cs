using System.Collections;
using UnityEngine;

public class ShieldBehaviour : MonoBehaviour
{
    public float shieldDuration = 7.0f;
    public Transform shieldPosition;
    public GameObject enemyExplosion;
    public AudioClip explosionSound;
    
    void Start()
    {
        StartCoroutine(ShieldActive());
    }

    IEnumerator ShieldActive()
    {
        yield return new WaitForSeconds(shieldDuration);
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Player") || !other.gameObject.CompareTag("bullet_lvl1") || !other.gameObject.CompareTag("bullet_lvl2"))
        {
            GameObject explosion = Instantiate(enemyExplosion, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(explosionSound, Camera.main.transform.position, 1.0f);
            Destroy(explosion, 0.5f);
            Destroy(other.gameObject);
        }
    }
}
