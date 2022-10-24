using UnityEngine;

public class MiniBossActivate : MonoBehaviour
{
    
    public float activationTime;
    public float activationPoint;
    public Enemy_FollowPlayer EnemyFollowPlayer;

    private float speed = 1f;

    void Start()
    {
        EnemyFollowPlayer = GameObject.Find("MiniBoss").GetComponent<Enemy_FollowPlayer>();
    }

    void Update()
    {
        if (GameManager.instance.timeCounter <= -activationTime)
        {
            if (gameObject.CompareTag("MiniBoss") && transform.position.y < activationPoint)
            {
                speed = 0.0f;
                GameManager.instance.miniBossActive = true;
                EnemyFollowPlayer.laserActivate = true;
            }
            if (gameObject.CompareTag("MiniBoss") && transform.position.y > activationPoint)
            {
                transform.Translate(Vector2.down * Time.deltaTime * speed);
            }
        }
    }
}
