using UnityEngine;

public class EnemyFollowPlayer : MonoBehaviour
{
    public float moveSpeed = 2f;

    private Rigidbody2D rb;
    private Vector2 movement;
    private GameObject player;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
    }

    void Update()
    {
        if (GameManager.instance.isGameActive && transform.position.y >= player.transform.position.y)
        {
            Vector3 direction = player.transform.position - transform.position;
            float angle = Mathf.Atan2(direction.x, -direction.y) * Mathf.Rad2Deg;
            rb.rotation = angle;
            direction.Normalize();
            movement = direction;
        }
        else
        {
            Vector3 direction = new Vector3(0,-1,0);
            float angle = Mathf.Atan2(direction.x, -direction.y) * Mathf.Rad2Deg;
            rb.rotation = -angle;
            movement = direction;
        }
    }
    private void FixedUpdate()
    {
        moveCharacter(movement);
    }
    void moveCharacter(Vector2 direction)
    {
        if (GameManager.instance.isGameActive)
        {
            rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
        }
    }
}