using System.Collections;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    public float speed = 20.0f;

    void Update()
    {
        if (GameManager.instance.timeCounter == -6)
        {
            speed = 0;
        }
        if (GameManager.instance.isGameActive)
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
        GameManager.instance.isSpeedUp = false;
    }
}
