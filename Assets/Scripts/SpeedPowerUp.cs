using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUp : MonoBehaviour
{
    //public bool isSpeedPowerUpActive;
    private MoveDown moveDownController;
    // Start is called before the first frame update

    private GameManager gameManager;

    void Start()
    {
        moveDownController = GameObject.Find("Background").GetComponent<MoveDown>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        StartCoroutine(SpeedPowerUpDestroy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            gameManager.isSpeedUp = true;
            if (moveDownController.speed == 10)
            {
                moveDownController.speed *= 5;
            }
            else if (moveDownController.speed == 5)
            {
                moveDownController.speed *= 10;
                gameManager.timeCounter -= 5;
            }
        }
    }

    IEnumerator SpeedPowerUpDestroy()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
