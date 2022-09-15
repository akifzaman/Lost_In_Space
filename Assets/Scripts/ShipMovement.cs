using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    private float moveSpeed;
    private bool moveRight;

    public MiniBossActivate MiniBoss;

    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        MiniBoss = GameObject.Find("MiniBoss").GetComponent<MiniBossActivate>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        moveSpeed = 2f;
        moveRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameManager.miniBossDestroyed)
        {
            if (transform.position.x > 2.3f)
            {
                moveRight = false;
            }
            else if (transform.position.x < -2.3f)
            {
                moveRight = true;
            }

            if (moveRight)
            {
                transform.position =
                    new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
            }
            else
            {
                transform.position =
                    new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
            }
        }
        else if (gameManager.miniBossDestroyed)
        {
            if (transform.position.x > 2.3f)
            {
                moveRight = false;
            }
            else if (transform.position.x < -2.3f)
            {
                moveRight = true;
            }

            if (moveRight)
            {
                transform.position =
                    new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
            }
            else
            {
                transform.position =
                    new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
            }
        }
    }
}
