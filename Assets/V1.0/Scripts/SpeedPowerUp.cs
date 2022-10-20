using System.Collections;
using UnityEngine;

public class SpeedPowerUp : MonoBehaviour
{
    private MoveDown moveDownController;

    void Start()
    {
        moveDownController = GameObject.Find("Background").GetComponent<MoveDown>();
        StartCoroutine(SpeedPowerUpDestroy());
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            GameManager.instance.isSpeedUp = true;
            if (moveDownController.speed == 10)
            {
                moveDownController.speed *= 5;
            }
            else if (moveDownController.speed == 5)
            {
                moveDownController.speed *= 10;
                GameManager.instance.timeCounter -= 5;
            }
        }
    }

    IEnumerator SpeedPowerUpDestroy()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
