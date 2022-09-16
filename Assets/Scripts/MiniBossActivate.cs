using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBossActivate : MonoBehaviour
{
    private float speed = 1f;
    //public bool miniBossActive = false;

    public GameManager gameManager;

    public float activationTime;

    public float activationPoint;

    public EnemyController enemyController;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        enemyController = GameObject.Find("MiniBoss").GetComponent<EnemyController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.timeCounter <= -activationTime)
        {
            if (gameObject.CompareTag("MiniBoss") && transform.position.y < activationPoint)
            {
                speed = 0.0f;
                gameManager.miniBossActive = true;
                enemyController.laserActivate = true;
            }
            if (gameObject.CompareTag("MiniBoss") && transform.position.y > activationPoint)
            {
                transform.Translate(Vector2.down * Time.deltaTime * speed);
            }
        }
    }
}
