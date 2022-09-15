using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeManager : MonoBehaviour
{
    private Vector3 startPos, shakePos;

    public float speed, amount, duration;

    private GameManager gameManager;
    public MiniBossActivate miniBoss;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        miniBoss = GameObject.Find("MiniBoss").GetComponent<MiniBossActivate>();
        shakePos = startPos = transform.position;
        speed = 2.34f;
        amount = 0.06f;
        duration = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (duration > 0 && gameManager.timeCounter < -40 && gameManager.miniBossActive == false)
        {
            Shake();
            duration -= Time.deltaTime;
        }
        else if (duration > 0 && gameManager.timeCounter < -5)
        {
            Shake();
            duration -= Time.deltaTime;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, Time.deltaTime * Mathf.Abs(speed));
        }
    }

    void Shake()
    {
        if (transform.position == shakePos)
        {
            shakePos = startPos + new Vector3(Random.Range(-amount, amount), Random.Range(-amount, amount), 0);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, shakePos, Time.deltaTime * Mathf.Abs(speed));
        }
    }
}
