using UnityEngine;
public class Enemy_RandomMovement : Enemy, IPooledObject
{
    private bool direction = false;
    private float initialPosition = 0;
    private float horizontalSpeed = 1.0f;
    
    void Update()
    {
        if (!GameManager.instance.isGameActive) return;
        MoveHorizontal();
        MoveDown();
    }
    private void OnEnable()
    {
        shooting = GetComponent<Shooting>();
        shooting.CanShoot = !GameManager.instance.OnSpeedUp;
    }
    public override void OnObjectSpawn()
    {
        enemyAudioSource = GetComponent<AudioSource>();

        shooting.CanShoot = !GameManager.instance.OnSpeedUp;
        StartCoroutine(shooting.Fire(bulletProperties));
    }
    private void MoveHorizontal()
    {
        float offSet = 0.5f;
        float speedMultiplier = 1.5f;
        if (direction)
        {
            transform.Translate(Vector2.right * Time.deltaTime * horizontalSpeed);
            if (transform.position.x > initialPosition + offSet)
            {
                direction = false;
            }
        }
        else
        {
            transform.Translate(Vector2.left * Time.deltaTime * horizontalSpeed * speedMultiplier);
            if (transform.position.x < initialPosition - offSet)
            {
                direction = true;
            }
        }
    }
}
