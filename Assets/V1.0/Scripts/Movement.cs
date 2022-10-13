using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 10.0f;

    private bool right = false;

    private float initialPosition = 0;

    private GameManager gameManager;

    void Start()
    {
        initialPosition = transform.position.x;
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }
    void Update()
    {
        if (gameManager.isGameActive)
        {
            if (right)
            {
                transform.Translate(Vector2.right * Time.deltaTime * speed);
                if (transform.position.x > initialPosition + 0.5f)
                {
                    right = false;
                }
            }
            else if (!right)
            {
                transform.Translate(Vector2.left * Time.deltaTime * speed);
                if (transform.position.x < initialPosition - 0.5f)
                {
                    right = true;
                }
            }
        }
        
    }
}
