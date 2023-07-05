using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool OnSpeedUp;
    public bool miniBossActive = false;
    public bool miniBossDestroyed = false;
    public bool isGameActive = false;
    public bool isShakeActive = false;
    public bool AllowMiniBossMovement = false;
    
    public int score = 0;

    public List<GameObject> powerUpList;

    public UIManager UiManager;
    public PlayerController playerController;
    public EnemySpawnManager enemySpawnManager;

    public UnityEvent SpeedPowerUp;

    #region Singleton
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
    #endregion

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

    public void UpdateScore(int amount)
    {
        UiManager.scoreText.text = (score + amount).ToString();
    }

    IEnumerator Timer()
    {
        
        for (int i = 0; i < powerUpList.Count; i++)
        {
            yield return new WaitForSeconds(Random.Range(10,11));
            GameObject powerUpObject = 
                Instantiate(powerUpList[i], new Vector2(Random.Range(-2.3f, 2.3f), Random.Range(3.0f, -3.0f)), powerUpList[i].transform.rotation);

        }
        isShakeActive = true;
        AllowMiniBossMovement = true;
        yield return new WaitForSeconds(10.0f);
        ActivateMiniBoss();
        AllowMiniBossMovement = false;
    }
    public void ActivateMiniBoss()
    {
        miniBossActive = true;
    }

}
