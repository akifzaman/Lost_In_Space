using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    private float moveSpeed;
    //private bool moveRight;

    public MiniBossActivate MiniBoss;

    public GameManager gameManager;

    public int prevMovement = 1, currentMovement = 1;

    private float xBoundary = 2;

    public float yBoundaryUp = 4.5f;
    public float yBoundaryDown = 3.0f;

    // Start is called before the first frame update 
    void Start()
    {
        MiniBoss = GameObject.Find("MiniBoss").GetComponent<MiniBossActivate>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        moveSpeed = 2f;
        //moveRight = true;
        StartCoroutine(RandomMovementGenerate());
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.miniBossActive)
        {
            StayInBound();
        }

        if (!gameManager.miniBossDestroyed && gameManager.miniBossActive)
        {
            //if (transform.position.x > 2.3f)
            //{
            //    moveRight = false;
            //}
            //else if (transform.position.x < -2.3f)
            //{
            //    moveRight = true;
            //}

            //if (moveRight)
            //{
            //    transform.position =
            //        new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
            //}
            //else
            //{
            //    transform.position =
            //        new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
            //}
            if (currentMovement == 1) //right
            {
                //transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
                transform.Translate(Vector2.right * Time.deltaTime * moveSpeed, Space.World);
            }

            else if (currentMovement == 2) //left
            {
                //transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
                transform.Translate(Vector2.left * Time.deltaTime * moveSpeed, Space.World);
            }
            else if (currentMovement == 3) //down
            {
                //transform.position = new Vector2(transform.position.y, transform.position.y + moveSpeed * Time.deltaTime);
                transform.Translate(Vector2.down * Time.deltaTime * moveSpeed, Space.World);
            }
            else if (currentMovement == 4) //down
            {
                //transform.position = new Vector2(transform.position.y, transform.position.y - moveSpeed * Time.deltaTime);
                transform.Translate(Vector2.up * Time.deltaTime * moveSpeed, Space.World);
            }
        }
        
    }

    IEnumerator RandomMovementGenerate()
    {
        if (prevMovement == currentMovement)
        {
            currentMovement = (prevMovement + currentMovement) % 5;
            //Debug.Log(currentMovement);
        }
        prevMovement = currentMovement;
        currentMovement = Random.Range(0, 4) + 1;
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(RandomMovementGenerate());
    }
    void StayInBound()
    {
        if (transform.position.x <= -xBoundary)
        {
            transform.position = new Vector2(-xBoundary, transform.position.y);
        }
        if (transform.position.x >= xBoundary)
        {
            transform.position = new Vector2(xBoundary, transform.position.y);
        }
        if (transform.position.y <= yBoundaryDown)
        {
            transform.position = new Vector2(transform.position.x, yBoundaryDown);
        }
        if (transform.position.y >= yBoundaryUp)
        {
            transform.position = new Vector2(transform.position.x, yBoundaryUp);
        }
    }
}
