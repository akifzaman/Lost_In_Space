using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isGameActive = false;

    public int score = 0;

    public int timeCounter = 90;

    public List<GameObject> powerUpList;

    public bool miniBossActive = false;
    public bool miniBossDestroyed = false;

    public bool OnSpeedUp;

    public PlayerController playerController;
    public MiniBoss miniBoss;
    public EnemySpawnManager enemySpawnManager;
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


    public void UpdateScore(int amount)
    {
        UiManager.scoreText.text = (score + amount).ToString();
    }
    public void StartGame()
    {
        isGameActive = true;
        playerController.StartGame();
        enemySpawnManager.StartGame();

        StartCoroutine(Timer());
    }

    public void GameOver()
    {
        isGameActive = false;
        UiManager.GameOver();
    }
    //ToDo - Need Refactor
    IEnumerator Timer()
    {
        if (isGameActive && timeCounter > -100)
        {
            timeCounter--;
            if (timeCounter > 20)
            {
                //enemySpawner.enemySpawnDelay -= 0.0031f;
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
        //Destroy(powerUpObject, 5);
    }

}
