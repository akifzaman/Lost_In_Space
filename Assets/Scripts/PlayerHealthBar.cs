using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    public Slider playerHealthBarSlider;
    public float amountOfBulletTaken; //amountOfHealth
    public float currentBulletTaken = 0; //currentHealth

    private GameManager gameManager;
    //private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        playerHealthBarSlider.maxValue = amountOfBulletTaken; //amountOfHealth
        playerHealthBarSlider.value = 0;
        playerHealthBarSlider.fillRect.gameObject.SetActive(false);
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
        if (currentBulletTaken >= amountOfBulletTaken && gameManager.isGameActive)
        {
            //gameManager.AddScore(amountToBeFed);
            gameManager.isGameActive = false;
            gameManager.GameOver();
            Destroy(gameObject, 0.1f);
        }
    }

    public void Heal(int heal)
    {
        currentBulletTaken = heal;
        playerHealthBarSlider.fillRect.gameObject.SetActive(true);
        playerHealthBarSlider.value = currentBulletTaken;
    }

}
