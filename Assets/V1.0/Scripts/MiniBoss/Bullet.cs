using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector2 moveDirection;
    public float moveSpeed;
    void Update()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.SetActive(false);
    }
    public void SetMoveDirection(Vector2 dir)
    {
        moveDirection = dir;
    }
}