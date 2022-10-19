using UnityEngine;

public class MiniBossActivate : MonoBehaviour
{
    
    public float activationTime;
    public float activationPoint;
    public EnemyController enemyController;

    private float speed = 1f;

    void Start()
    {
        enemyController = GameObject.Find("MiniBoss").GetComponent<EnemyController>();
    }

    void Update()
    {
        if (GameManager.instance.timeCounter <= -activationTime)
        {
            if (gameObject.CompareTag("MiniBoss") && transform.position.y < activationPoint)
            {
                speed = 0.0f;
                GameManager.instance.miniBossActive = true;
                enemyController.laserActivate = true;
            }
            if (gameObject.CompareTag("MiniBoss") && transform.position.y > activationPoint)
            {
                transform.Translate(Vector2.down * Time.deltaTime * speed);
            }
        }
    }
}
