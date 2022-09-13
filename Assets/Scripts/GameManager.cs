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

    public List<GameObject> powerUpList;
    // Start is called before the first frame update
    void Start()
    {
        
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
        if (isGameActive)
        {
            timeCounter--;
        }

        if (timeCounter == 195)
        {
            PowerUpSpawner(0);
        }
        yield return new WaitForSeconds(1);
        timerText.text = "Time: " + timeCounter;
        StartCoroutine(Timer());
    }

    public void PowerUpSpawner(int powerUpIndex)
    {
        Instantiate(powerUpList[powerUpIndex], new Vector2(Random.Range(-2.3f, 2.3f), Random.Range(5.5f, -5.5f)), powerUpList[powerUpIndex].transform.rotation);
    }
}
