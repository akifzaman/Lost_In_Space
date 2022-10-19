using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    private Slider playerHealthBarSlider;
    public float amountOfBulletTaken; //amountOfHealth
    public float currentBulletTaken = 0; //currentHealth

    private GameManager gameManager;

    public GameObject enemyExplosion;

    private AudioSource playerAudio;

    public AudioClip playerExplosionSound;
    //private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.instance;
        playerHealthBarSlider = gameManager.UiManager.PlayerHealthBarSlider;

        playerHealthBarSlider.maxValue = amountOfBulletTaken; //amountOfHealth
        playerHealthBarSlider.value = 0;
        playerHealthBarSlider.fillRect.gameObject.SetActive(false);
        playerAudio = GetComponent<AudioSource>();
    }

    public void DamageTaken(float amount) //damageTaken
    {
        currentBulletTaken += amount; //currentHealth
        if (currentBulletTaken < 0)
        {
            currentBulletTaken = 0;
        }
        playerHealthBarSlider.fillRect.gameObject.SetActive(true);
        playerHealthBarSlider.value = currentBulletTaken; //currentHealth

        if (currentBulletTaken >= amountOfBulletTaken && gameManager.isGameActive && gameObject.CompareTag("Player"))
        {
            GameObject explosion = Instantiate(enemyExplosion, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(playerExplosionSound, Camera.main.transform.position, 1.0f);
            Destroy(explosion, 0.5f);
            Destroy(gameObject);
            gameManager.isGameActive = false;
            gameManager.GameOver();
        }

        else if (currentBulletTaken >= amountOfBulletTaken && gameManager.isGameActive && gameManager.miniBossActive)
        {
            gameManager.isGameActive = false;
            gameManager.miniBossActive = false;
            GameObject explosion = Instantiate(enemyExplosion, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(playerExplosionSound, Camera.main.transform.position, 1.0f);
            Destroy(explosion, 0.5f);
            Destroy(gameObject);
            gameManager.GameOver();
        }
    }

    public void Heal(int heal)
    {
        currentBulletTaken = heal;
        playerHealthBarSlider.fillRect.gameObject.SetActive(true);
        playerHealthBarSlider.value = currentBulletTaken;
    }

}
