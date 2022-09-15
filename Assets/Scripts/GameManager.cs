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
    // Start is called before the first frame update
    void Start()
    {
        enemySpawner = GameObject.Find("EnemySpawner").GetComponent<EnemySpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
        }

        if (timeCounter == 190)
        {
            PowerUpSpawner(0); //sonic
        }
        if (timeCounter == 140)
        {
            PowerUpSpawner(1); //armour
        }
        if (timeCounter == 120)
        {
            PowerUpSpawner(2); //heal
            enemySpawner.enemySpawnDelay -= 0.1f;
        }
        if (timeCounter == 100)
        {
            PowerUpSpawner(3);
            enemySpawner.enemySpawnDelay -= 0.2f; //double bullet
        }
        if (timeCounter == 70)
        {
            PowerUpSpawner(2); //heal
        }
        if (timeCounter == 45)
        {
            PowerUpSpawner(0); //sonic
        }
        if (timeCounter == 5)
        {
            PowerUpSpawner(2); //heal
        }
        yield return new WaitForSeconds(1);
        //timerText.text = "Time: " + timeCounter;
        StartCoroutine(Timer());
    }

    public void PowerUpSpawner(int powerUpIndex)
    {
        Instantiate(powerUpList[powerUpIndex], new Vector2(Random.Range(-2.3f, 2.3f), Random.Range(3.0f, -3.0f)), powerUpList[powerUpIndex].transform.rotation);
    }
}
