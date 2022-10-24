using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isGameActive = false;
    
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI laserText;

    public int laserCount = 3;
    public int score = 0;

    public int timeCounter = 90;

    public bool isSpeedUp = false;

    public EnemySpawnManager enemySpawner;

    public List<GameObject> powerUpList;

    public bool miniBossActive = false;
    public bool miniBossDestroyed = false;

    public PlayerController playerController;

    public UIManager UiManager;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        UiManager.InitialGame();
    }

    void Start()
    {
        enemySpawner = GameObject.FindObjectOfType<EnemySpawnManager>();
    }

    void Update()
    {
        if (miniBossActive)
        {
            UiManager.EnemyBossHealthBarSlider.gameObject.SetActive(true);
        }
        scoreText.text = $" {score:0000}";
        laserText.SetText("Laser: " + laserCount);
    }

    public void StartGame()
    {
        isGameActive = true;
        GameObject slider = UiManager.PlayerHealthBarSlider.gameObject;
        slider.SetActive(true);
        playerController.StartGame(slider);
        StartCoroutine(Timer());
    }

    public void GameOver() => UiManager.GameOver(); //function of only one line can be written like this

    IEnumerator Timer()
    {
        if (isGameActive && timeCounter > -100)
        {
            timeCounter--;
            if (timeCounter > 20)
            {
                enemySpawner.enemySpawnDelay -= 0.0031f;
            }
        }

        if (timeCounter == 80)
        {
            PowerUpSpawner(0); //sonic
        }
        if (timeCounter == 65)
        {
            PowerUpSpawner(1); //armour
        }
        if (timeCounter == 50)
        {
            PowerUpSpawner(2); //heal
        }
        if (timeCounter == 35)
        {
            PowerUpSpawner(3); //double bullet
        }
        if (timeCounter == 25)
        {
            PowerUpSpawner(2); //heal
        }
        if (timeCounter == 15)
        {
            PowerUpSpawner(0); //sonic
        }
        if (timeCounter == 5)
        {
            PowerUpSpawner(2); //heal
        }
        yield return new WaitForSeconds(1);
        StartCoroutine(Timer());
    }

    public void PowerUpSpawner(int powerUpIndex)
    {
        GameObject powerUpObject = Instantiate(powerUpList[powerUpIndex], new Vector2(Random.Range(-2.3f, 2.3f), Random.Range(3.0f, -3.0f)), powerUpList[powerUpIndex].transform.rotation);
        Destroy(powerUpObject, 5);
    }

}
