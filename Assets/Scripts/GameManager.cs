using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isGameActive = false;
   
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI laserText;

    public int laserCount = 3;
    public int score = 0;

    public Button restartButton;

    public GameObject titleScreen;
    public Vector2 prevPosition;
    public Vector2 currentPosition;

    public TextMeshProUGUI timerText;
    public int timeCounter = 200;

    public bool isSpeedUp = false;

    public EnemySpawnManager enemySpawner;

    public List<GameObject> powerUpList;

    public bool miniBossActive = false;
    public bool miniBossDestroyed = false;
    public bool mainBossActive = false;

    // Start is called before the first frame update
    void Start()
    {
        enemySpawner = GameObject.Find("EnemySpawner").GetComponent<EnemySpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = $" {score:0000}";
        laserText.SetText("Laser: " + laserCount);
    }

    public void StartGame()
    {
        titleScreen.gameObject.SetActive(false);
        StartCoroutine(Timer());
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

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

        if (timeCounter == 160)
        {
            PowerUpSpawner(0); //sonic
        }
        if (timeCounter == 130)
        {
            PowerUpSpawner(1); //armour
        }
        if (timeCounter == 110)
        {
            PowerUpSpawner(2); //heal
        }
        if (timeCounter == 80)
        {
            PowerUpSpawner(3);
        }
        if (timeCounter == 50)
        {
            PowerUpSpawner(2); //heal
        }
        if (timeCounter == 30)
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
        Instantiate(powerUpList[powerUpIndex], new Vector2(Random.Range(-2.3f, 2.3f), Random.Range(3.0f, -3.0f)), powerUpList[powerUpIndex].transform.rotation);
    }

}
