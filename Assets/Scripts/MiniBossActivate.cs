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

    private SuperSplashActivate superSplashActivate;

    //public GameObject sliderCanvas;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        enemyController = GameObject.Find("MiniBoss").GetComponent<EnemyController>();
        superSplashActivate = GameObject.Find("Player").GetComponent<SuperSplashActivate>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.timeCounter <= -activationTime)
        {
            //sliderCanvas.SetActive(true);
            //superSplashActivate.superSplashCounter = 0;
            if (gameObject.CompareTag("MiniBoss") && transform.position.y < activationPoint)
            {
                speed = 0.0f;
                gameManager.miniBossActive = true;
                enemyController.laserActivate = true;
                superSplashActivate.superSplashCounter = 0;
            }
            if (gameObject.CompareTag("MiniBoss") && transform.position.y > activationPoint)
            {
                transform.Translate(Vector2.down * Time.deltaTime * speed);
            }
        }
    }
}
