using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_RandomMovement : Enemy, IPooledObject
{
    private bool direction = false;
    private float initialPosition = 0;
    private float horizontalSpeed = 1.0f;
    
    void Update()
    {
        if (!GameManager.instance.isGameActive) return;
        if (direction)
        {
            transform.Translate(Vector2.right * Time.deltaTime * horizontalSpeed);
            if (transform.position.x > initialPosition + 0.5f)
            {
                direction = false;
            }
        }
        else if (!direction)
        {
            transform.Translate(Vector2.left * Time.deltaTime * horizontalSpeed * 1.5f);
            if (transform.position.x < initialPosition - 0.5f)
            {
                direction = true;
            }
        }
        transform.Translate(Vector2.down * Time.deltaTime * enemyProperties.Speed, Space.World);
        
    }
  

    public override void OnObjectSpawn()
    {
        enemyAudioSource = GetComponent<AudioSource>();

        shooting.CanShoot = !GameManager.instance.OnSpeedUp;
        StartCoroutine(shooting.Fire(bulletProperties));
    }
    private void OnEnable()
    {
        shooting = GetComponent<Shooting>();
        shooting.CanShoot = !GameManager.instance.OnSpeedUp;
    }
}
