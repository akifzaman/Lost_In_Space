using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        isGameActive = true;
        StartCoroutine(Timer());
    }

    
    public void GameOver() => UiManager.GameOver();
  

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
        Instantiate(powerUpList[powerUpIndex], new Vector2(Random.Range(-2.3f, 2.3f), Random.Range(3.0f, -3.0f)), powerUpList[powerUpIndex].transform.rotation);
    }

}
