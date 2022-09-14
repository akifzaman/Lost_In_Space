using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    public float speed = 20.0f;
    private GameManager gameManager;
    private SpeedPowerUp speedPowerUp;
    
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive)
        {
            transform.Translate(Vector2.down * Time.deltaTime * speed);
        }

        if (speed == 50)
        {
            StartCoroutine(SpeedPowerUpEnd());
        }
    }
    IEnumerator SpeedPowerUpEnd()
    {
        yield return new WaitForSeconds(8.0f);
        speed = 10;
        gameManager.isSpeedUp = false;
    }
}
