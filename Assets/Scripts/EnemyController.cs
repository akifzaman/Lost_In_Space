using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 3.0f;
    [SerializeField] private float boundary = 6.0f;
    [SerializeField] private float rotateAngle = 1.0f;
    [SerializeField] private bool lookDirectionAllow;

    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0.0f, 0.0f * Time.deltaTime, rotateAngle, 0.0f);

        if (transform.position.y > player.transform.position.y && lookDirectionAllow)
        {
            Vector2 lookDirection = (player.transform.position - transform.position).normalized;
            transform.Translate(lookDirection * Time.deltaTime * speed, Space.World);
        }
        else
        {
            transform.Translate(Vector2.down * Time.deltaTime * speed, Space.World);
        }

        if (transform.position.y < -boundary)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

}
