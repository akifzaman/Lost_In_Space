using System.Collections;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public int prevMovement = 1, currentMovement = 1;
    public float yBoundaryUp = 4.5f;
    public float yBoundaryDown = 3.0f;
    public float moveSpeed;
    private float xBoundary = 2;

    void Start()
    {
        moveSpeed = 2f;
        StartCoroutine(RandomMovementGenerate());
    }
    void Update()
    {

        if (GameManager.instance.miniBossActive)
        {
            StayInBound();
        }

        if (!GameManager.instance.miniBossDestroyed && GameManager.instance.miniBossActive)
        {
            if (currentMovement == 1) //right
            {
                transform.Translate(Vector2.right * Time.deltaTime * moveSpeed, Space.World);
            }

            else if (currentMovement == 2) //left
            {
                transform.Translate(Vector2.left * Time.deltaTime * moveSpeed, Space.World);
            }
            else if (currentMovement == 3) //down
            {
                transform.Translate(Vector2.down * Time.deltaTime * moveSpeed, Space.World);
            }
            else if (currentMovement == 4) //up
            {
                transform.Translate(Vector2.up * Time.deltaTime * moveSpeed, Space.World);
            }
        }
        
    }
    IEnumerator RandomMovementGenerate()
    {
        if (prevMovement == currentMovement)
        {
            currentMovement = (prevMovement + currentMovement) % 5;
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
