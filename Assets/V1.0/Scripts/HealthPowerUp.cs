using System.Collections;
using UnityEngine;

public class HealthPowerUp : MonoBehaviour
{
    private PlayerHealthBar playerHealthBar;

    void Start()
    {
        if (GameManager.instance.isGameActive)
        {
            playerHealthBar = GameObject.Find("Player").GetComponent<PlayerHealthBar>();
        }
        StartCoroutine(HealthPowerUpDestroy());
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerHealthBar.Heal(0);
        }
        Destroy(gameObject);
    }
    IEnumerator HealthPowerUpDestroy()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
