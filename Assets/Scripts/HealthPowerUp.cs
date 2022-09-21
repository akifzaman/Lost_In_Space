using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerUp : MonoBehaviour
{
    private PlayerHealthBar playerHealthBar;

    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        if (gameManager.isGameActive)
        {
            playerHealthBar = GameObject.Find("Player").GetComponent<PlayerHealthBar>();
        }
        StartCoroutine(HealthPowerUpDestroy());

    }

    // Update is called once per frame
    void Update()
    {
        
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
