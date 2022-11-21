using UnityEngine;
using System.Collections;
public class BackgroundController : MonoBehaviour
{
    public float speed = 5.0f;
    private Vector2 startPos;
    private float repeatHeight;
    [SerializeField] private float movementSpeedMultiplier = 20.0f;

    void Start()
    {
        startPos = transform.position;
        repeatHeight = GetComponent<BoxCollider2D>().size.y / movementSpeedMultiplier; 
        GameManager.instance.SpeedPowerUp.AddListener(() =>
        {
            speed *= 10;
            StartCoroutine(SpeedPowerUpEnd());
        });
    }

    void Update()
    {
        if (GameManager.instance.isGameActive)
        {
            transform.Translate(Vector2.down * Time.deltaTime * speed);
        }
        if (transform.position.y < startPos.y - repeatHeight)
        {
            transform.position = startPos;
        }
    }

    IEnumerator SpeedPowerUpEnd()
    {
        yield return new WaitForSeconds(8.0f);
        speed = 5;
        GameManager.instance.OnSpeedUp = false;
    }
}
