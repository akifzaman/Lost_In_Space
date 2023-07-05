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
        gameObject.SetActive(false);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
		GameObject explosion = Instantiate(enemyExplosion, transform.position, Quaternion.identity);
	    AudioSource.PlayClipAtPoint(explosionSound, Camera.main.transform.position, 1.0f);
	    Destroy(explosion, 0.5f);
	    other.gameObject.SetActive(false);
    }
}
