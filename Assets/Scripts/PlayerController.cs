using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    private float xBoundary = 2.40f;
    private float yBoundaryUp = 4.78f;
    private float yBoundaryDown = -4.60f;
    public float speed = 10.0f;

    public float health = 100.0f;
    private PlayerHealthBar _playerHealthBar;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        StayInBound();

        if (health == 0.0f)
        {
            Destroy(gameObject);
        }

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector2.left * Time.deltaTime * horizontalInput * speed);
        transform.Translate(Vector2.down * Time.deltaTime * verticalInput * speed);
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
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!gameObject.CompareTag("Player"))
        {
            _playerHealthBar.DamageTaken(1);
        }
    }
}
