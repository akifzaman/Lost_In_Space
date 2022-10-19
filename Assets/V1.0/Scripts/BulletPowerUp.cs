using System.Collections;
using UnityEngine;

public class BulletPowerUp : MonoBehaviour
{
    public Shooting shooting;
    public DoubleShooting doubleShooting;
    
    void Start()
    {
        shooting = GameObject.Find("Player").GetComponent<Shooting>();
        doubleShooting = GameObject.Find("Player").GetComponent<DoubleShooting>();
        StartCoroutine(BulletPowerUpDestroy());
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            doubleShooting.isActivatedTwo = true;
            shooting.isActivatedOne = false;
            Destroy(gameObject);
        }
    }
    IEnumerator BulletPowerUpDestroy()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
